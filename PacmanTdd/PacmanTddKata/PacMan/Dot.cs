namespace PacmanTddKata.PacMan
{
    internal class Dot : Bonus
    {
        public Dot() : base("Dot", 10)
        {
        }

        protected override string OnApply(GameState state)
        {
            base.OnApply(state);
            return "Dot";
        }
    }
}