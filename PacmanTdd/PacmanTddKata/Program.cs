using System;
using System.IO;
using System.Linq;
using PacmanTddKata.PacMan;

namespace PacmanTddKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IUserExperience consoleUi = new ConsoleUi();
            var game = PacmanGame.Create(5000, 3, consoleUi);
            var collisionFile = args.FirstOrDefault() ?? @"KataPacman-seq.txt";
            var collisions = File.ReadAllText(collisionFile);

            var result = game.Run(new TextCollisionSource(collisions));

            Console.WriteLine();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}