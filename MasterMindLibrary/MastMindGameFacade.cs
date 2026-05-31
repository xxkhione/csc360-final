using System;
using System.Collections.Generic;
using MasterMindLibrary.Factories;
using MasterMindLibrary.Strategies;

namespace MasterMindLibrary
{
    public class MasterMindGameFacade
    {
        private readonly List<Peg> _pegList;
        private readonly int _difficulty;
        private int _maxTurns;

        private readonly IGuessEvaluationStrategy _guessEvaluationStrategy;
        private readonly MasterMindEngine _engine;

        public MasterMindGameFacade(List<Peg> pegList, int difficulty, int maxTurns)
        {
            _pegList = pegList;
            _difficulty = difficulty;
            _maxTurns = maxTurns;

            _guessEvaluationStrategy = new StandardGuessEvaluationStrategy();
            _engine = new MasterMindEngine(_guessEvaluationStrategy);
        }

        public void RunGame()
        {
            List<Attempt> allAttempts = new List<Attempt>();

            CodeFactory factory = CreateFactory();
            IAnswerGenerator generator = factory.CreateGenerator();
            List<int> answer = generator.GenerateAnswer();
            int maxPegs = answer.Count;

            bool gameWon = false;

            do
            {
                Attempt userAttempt = GetAttemptFromUser(maxPegs, allAttempts);
                string evaluation =_engine.EvaluateAttempt(answer, userAttempt);

                allAttempts.Add(userAttempt);

                Console.Clear();
                Console.WriteLine(_maxTurns);
                MMLib.ShowAttempts(allAttempts, _pegList, "x");
                Console.WriteLine(evaluation);

                gameWon = userAttempt.CorrectAnswerCount == maxPegs;

                _maxTurns--;
            }
            while (!gameWon && _maxTurns != 0);

            ShowGameResult(gameWon, answer);
        }

        private CodeFactory CreateFactory()
        {
            switch (_difficulty)
            {
                case 1:
                    return new EasyCodeFactory();
                case 2:
                    return new MediumCodeFactory();
                case 3:
                    return new HardCodeFactory();
                default:
                    return new EasyCodeFactory();
            }
        }

        private Attempt GetAttemptFromUser(int maxPegs, List<Attempt> allAttempts)
        {
            Attempt userAttempt = new Attempt();
            List<string> colorOptions = MMLib.GetColorOptions(maxPegs, _pegList);

            for (int i = 0; i < maxPegs; i++)
            {
                Console.Clear();
                Console.WriteLine(_maxTurns);
                MMLib.ShowAttempts(allAttempts, _pegList, "x");
                MMLib.ShowChosenPegs(userAttempt, _pegList);

                int colorSelection = MMLib.GetConsoleMenu(colorOptions) - 1;
                userAttempt.AttemptList.Add(colorSelection);
            }

            return userAttempt;
        }

        private void ShowGameResult(bool gameWon, List<int> answer)
        {
            Console.Clear();

            if (gameWon)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congratulations, you have won the game!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lose, you have ran out of turns.");
                Console.ResetColor();
            }

            MMLib.ShowAnswer(answer, _pegList, "x");
        }
    }
}