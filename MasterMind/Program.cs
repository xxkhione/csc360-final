using System;
using System.Collections.Generic;
using MasterMindLibrary;


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
            List<string> difficulties = new List<string>() { "Easy", "Medium", "Hard" };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to MasterMind!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            int difficulty = MMLib.GetConsoleMenu(difficulties);
            int maxTurns = MMLib.GetConsoleInt("How many turns would you like? (Max is 25 turns) ", 1, 25);
            Console.ResetColor();

            MasterMindGameFacade game = new MasterMindGameFacade(pegList, difficulty, maxTurns);
            game.RunGame();
        }
    }
}
