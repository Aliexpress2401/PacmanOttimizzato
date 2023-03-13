namespace PacmanTddKata.PacMan
{
    public readonly struct GameResult
    {
        public GameResult(int score, int lives)
        {
            Score = score;
            Lives = lives;
        }

        public int Score { get; }
        public int Lives { get; }

        public override string ToString()
        {
            return $"Lives: {Lives} | Score: {Score}";
        }
    }
}