using System;

namespace PacmanTddKata.PacMan
{
    internal class Ghost : Bonus
    {
        public Ghost() : base("Ghost", 200)
        {
        } 

        protected override string OnApply(GameState state)
        {
            var exp = Math.Min(state.EatenGhosts, 3);
            var pow = (int) Math.Pow(2, exp);

            var increment = Points * pow;

            state.Score += increment;

            state.EatenGhosts++;

            return $"Pacman ate {Name} and gained {increment} points";
        }
    }
}