using System;
using System.Collections.Generic;
using System.Linq;
using MasterMindLibrary;
using MasterMindLibrary.Factories;
using MasterMindLibrary.Strategies;


namespace MasterMind
{
    class Program
    {
        static List<Peg> pegList = new List<Peg>()
        {
            new Peg(ConsoleColor.White, ConsoleColor.Red),
            new Peg(ConsoleColor.White, ConsoleColor.Blue),
            new Peg(ConsoleColor.Black, ConsoleColor.Green),
            new Peg(ConsoleColor.Black, ConsoleColor.Yellow),
            new Peg(ConsoleColor.Black, ConsoleColor.Cyan),
            new Peg(ConsoleColor.White, ConsoleColor.Magenta),
            new Peg(ConsoleColor.White, ConsoleColor.DarkGray),
            new Peg(ConsoleColor.White, ConsoleColor.DarkRed)
        };

        static void Main(string[] args)
        {
            List<Attempt> allAttempts = new List<Attempt>();
            List<string> difficulties = new List<string>() { "Easy", "Medium", "Hard" };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to Mastermind!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            int difficulty = MMLib.GetConsoleMenu(difficulties);
            int maxTurns = MMLib.GetConsoleInt("How many turns would you like? (Max is 25 turns) ", 1, 25);
            Console.ResetColor();

            CodeFactory factory = null;
            switch(difficulty)
            {
                case 1:
                    factory = new EasyCodeFactory();
                    break;
                case 2:
                    factory = new MediumCodeFactory();
                    break;
                case 3:
                    factory = new HardCodeFactory();
                    break;
            }

            IAnswerGenerator generator = factory.CreateGenerator();
            List<int> answer = generator.GenerateAnswer();
            int maxPegs = answer.Count;

            IGuessEvaluationStrategy guessEvaluationStrategy = new StandardGuessEvaluationStrategy();
            MasterMindEngine engine = new MasterMindEngine(guessEvaluationStrategy);

            //show cheat? 
            //MMLib.Cheat(answer, pegList);

            bool gameWon = false;
            do
            {
                Attempt userAttempt = GetAttemptFromUser(maxPegs, allAttempts, maxTurns);
                string evaluation = engine.EvaluateAttempt(answer, userAttempt);
                allAttempts.Add(userAttempt);
                gameWon = userAttempt.CorrectAnswerCount == maxPegs;
                maxTurns--;
            } while(!gameWon && maxTurns != 0);

            if(gameWon)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations, you have won the game!");
                Console.ResetColor();
            } 
            else if(maxTurns == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose, you have ran out of turns.");
                Console.ResetColor();
            }
            MMLib.ShowAnswer(answer, pegList, "x");
        }

        static Attempt GetAttemptFromUser(int maxPegs, List<Attempt> allAttempts, int maxTurns)
        {
            Attempt userAttempt = new Attempt();
            List<string> colorOptions = MMLib.GetColorOptions(maxPegs, pegList);
            for(int i = 0; i < maxPegs; i++)
            {
                Console.Clear();
                Console.WriteLine(maxTurns);
                MMLib.ShowAttempts(allAttempts, pegList, "x");
                MMLib.ShowChosenPegs(userAttempt, pegList);
                int colorSelection = MMLib.GetConsoleMenu(colorOptions) - 1;
                userAttempt.AttemptList.Add(colorSelection);
            }
            Console.Clear();
            Console.WriteLine(maxTurns);
            MMLib.ShowAttempts(allAttempts, pegList, "x");
            MMLib.ShowChosenPegs(userAttempt, pegList);
            return userAttempt;
        }
    }
}
