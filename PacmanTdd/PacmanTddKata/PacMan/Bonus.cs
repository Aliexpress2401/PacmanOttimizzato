namespace PacmanTddKata.PacMan
{
    internal abstract class Bonus : IBonus
    {
        public string Name { get; }
        protected int Points { get; }

        protected Bonus(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public string Apply(GameState state)
        {
            var initialScore = state.Score;
            var feedback = OnApply(state);
            if (state.Score >= 10000 && initialScore < 10000)
            {
                state.Lives += 1;
                feedback += " winning a extra life!!!";
            }

            return feedback;
        }

        protected virtual string OnApply(GameState state)
        {
            state.Score += Points;
            return $"PacMan ate {Name} and gained {Points} points";
        }
    }
}