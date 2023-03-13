using System;

namespace PacmanTddKata.PacMan
{
    internal class DefaultBonusFactory : IBonusFactory
    {
        public IBonus Create(string move)
        {
            switch (move.ToUpperInvariant())
            {
                case "DOT":
                    return new Dot();
                case "VULNERABLEGHOST":
                    return new Ghost();
                case "INVINCIBLEGHOST":
                    return new InvincibleDecorator(new Ghost());
                case "CHERRY":
                    return new Fruit("Cherry", 100);
                case "STRAWBERRY":
                    return new Fruit("Strawberry", 300);
                case "ORANGE":
                    return new Fruit("Orange", 500);
                case "APPLE":
                    return new Fruit("Apple", 700);
                case "MELON":
                    return new Fruit("Melon", 1000);
                case "GALAXIAN":
                    return new Fruit("Galaxian", 2000);
                case "BELL":
                    return new Fruit("Bell", 3000);
                case "KEY":
                    return new Fruit("Key", 5000);

                default:
                    throw new NotSupportedException($"Unknown token {move}");
            }
        }
    }
}