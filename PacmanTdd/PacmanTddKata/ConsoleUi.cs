using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PacmanTddKata.PacMan;

namespace PacmanTddKata
{
    internal class ConsoleUi : IUserExperience
    {
        private readonly Queue<string> _buffer = new Queue<string>();

        public void Display(GameState state, string feedback)
        {
            _buffer.Enqueue(feedback);
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("------------------------------- PACMAN GAME ------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine();
            foreach (var line in _buffer.TakeLast(16))
            {
                Console.WriteLine(" - " + line);
            } 
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"Score: {state.Score} - Lives: {state.Lives}");
            Thread.Sleep(50);
        }
    }
}