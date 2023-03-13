namespace PacmanTddKata.PacMan
{
    internal interface IBonusFactory
    {
        IBonus Create(string move);
    }
}