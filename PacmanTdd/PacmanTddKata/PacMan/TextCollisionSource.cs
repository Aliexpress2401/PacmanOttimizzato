using System;
using System.Collections.Generic;

namespace PacmanTddKata.PacMan
{
    public class TextCollisionSource : ICollisionSource
    {
        private readonly Queue<string> _moves;

        public TextCollisionSource(string moves)
        {
            var tokens = moves.Split(',', StringSplitOptions.RemoveEmptyEntries);
            _moves = new Queue<string>(tokens);
        }

        public string GetMove()
        {
            return _moves.Dequeue();
        }

        public bool HasMoves()
        {
            return _moves.Count > 0;
        }
    }
}