namespace PacmanTddKata.PacMan
{
    public class PacmanGame
    {
        private readonly IBonusFactory _bonusFactory;
        private static IUserExperience _ui;

        private PacmanGame()
        {
            State = new GameState();
            _bonusFactory = new DefaultBonusFactory();
        }

        private GameState State { get; }

        public static PacmanGame Create(int initialScore, int initialLives, IUserExperience userExperience = null)
        {
            _ui = userExperience ?? new NullUi();
            var g = new PacmanGame();
            g.State.Score = initialScore;
            g.State.Lives = initialLives;
            return g;
        }


        public GameResult Run(ICollisionSource collisionSource)
        {
            while (collisionSource.HasMoves() && !HasEnded())
            {
                var move = collisionSource.GetMove();
                var bonus = _bonusFactory.Create(move);
                var feedback = bonus.Apply(State);
                _ui.Display(State, feedback);
            }


            return new GameResult(State.Score, State.Lives);
        }

        private bool HasEnded()
        {
            return State.Lives <= 0;
        }
    }
}