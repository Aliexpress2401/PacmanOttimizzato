namespace PacmanTddKata.PacMan
{
    internal class InvincibleDecorator : IBonus
    {
        private readonly Bonus _bonus;

        public InvincibleDecorator(Bonus bonus)
        {
            _bonus = bonus;
        }
 

        public string Apply(GameState state)
        {
            state.Lives -= 1;
            return $"Pacman found a invincible {_bonus.Name} and loose a life";
        }
    }
}