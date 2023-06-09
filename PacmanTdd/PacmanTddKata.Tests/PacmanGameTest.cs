using Moq;
using PacmanTddKata.PacMan;
using SharpTestsEx;
using Xunit;

namespace PacmanTddKata.Tests
{
    public class PacmanGameTest
    {
        [Fact(DisplayName = "DATO Pacman " +
            "QUANDO non ci sono collisioni, " +
            "ALLORA il gioco termina con il punteggio iniziale")]
        public void Test1()
        {
            //arrange
            var sut = PacmanGame.Create(5000, 3);
            ICollisionSource collision = new TextCollisionSource("");

            //act
            var res = sut.Run(collision);

            //assert
            res.Should().Be(new GameResult(5000, 3));
        }

        [Theory(DisplayName = "DATO Pacman" +
            "QUANDO ogni Dot viene mangiato" +
            "ALLORA Pacman guadagna 10 punti")]
        [InlineData(5000, "Dot", 5010)]
        [InlineData(5000, "Dot,Dot,Dot", 5030)]
        public void Test2(int initialScore, string collisions, int finalScore)
        {
            var sut = PacmanGame.Create(initialScore, 3);
            ICollisionSource collision = new TextCollisionSource(collisions);

            var res = sut.Run(collision);

            res.Should().Be(new GameResult(finalScore, 3));
        }

        [Theory(DisplayName = "DATO un Fantasma " +
            "QUANDO viene mangiato da Pacman" +
            "ALLORA il punteggio aumenta esponenzialmente")]
        [InlineData(5000, "VulnerableGhost", 5200)]
        [InlineData(5000, "VulnerableGhost,VulnerableGhost", 5600)]
        [InlineData(5000, "VulnerableGhost,VulnerableGhost,VulnerableGhost,VulnerableGhost", 8000)]
        public void Test3(int initialScore, string collisions, int finalScore)
        {
            var sut = PacmanGame.Create(initialScore, 3);
            ICollisionSource collision = new TextCollisionSource(collisions);

            var res = sut.Run(collision);

            res.Should().Be(new GameResult(finalScore, 3));
        }

        [Theory(DisplayName = "DATO un frutto" +
            "QUANDO viene mangiato da Pacman" +
            "ALLORA prende punti")]
        [InlineData(0, "Cherry", 100)]
        [InlineData(0, "Strawberry", 300)]
        [InlineData(0, "Orange", 500)]
        [InlineData(0, "Apple", 700)]
        [InlineData(0, "Melon", 1000)]
        [InlineData(0, "Galaxian", 2000)]
        [InlineData(0, "Bell", 3000)]
        [InlineData(0, "Key", 5000)]
        public void Test4(int initialScore, string collisions, int finalScore)
        {
            var sut = PacmanGame.Create(initialScore, 3);
            ICollisionSource collision = new TextCollisionSource(collisions);

            var res = sut.Run(collision);

            res.Should().Be(new GameResult(finalScore, 3));
        }


        [Fact(DisplayName = "DATO un fantasma cattivo" +
            "QUANDO incontra Pacman" +
            "ALLORA Pacman perde una vita")]
        public void Test5()
        {
            var sut = PacmanGame.Create(5000, 3);
            ICollisionSource collision = new TextCollisionSource("InvincibleGhost");

            var res = sut.Run(collision);

            res.Should().Be(new GameResult(5000, 2));
        }


        [Fact(DisplayName = "DATO Pacman" +
            "QUANDO finisce le vite " +
            "ALLORA il gioco termina")]
        public void Test6()
        {
            var sut = PacmanGame.Create(5000, 2);
            ICollisionSource collision =
                new TextCollisionSource("InvincibleGhost,Dot,InvincibleGhost,Dot,Dot,InvincibleGhost,Apple");

            var res = sut.Run(collision);

            res.Should().Be(new GameResult(5010, 0));
        }


        [Fact(DisplayName = "DATO Pacman" +
            "QUANDO raggiunge 10000 punti" +
            "ALLORA guadagna una vita")]
        public void Test7()
        {
            var sut = PacmanGame.Create(9990, 2);
            ICollisionSource collision = new TextCollisionSource("Dot");

            var res = sut.Run(collision);

            res.Should().Be(new GameResult(10000, 3));
        }


        [Fact(DisplayName = "DATO Pacman" +
            "QUANDO Per ogni collisione " +
            "ALLORA pacman mostra lo stato di gioco")]
        public void Test8()
        {
            var ui = new Mock<IUserExperience>();
            var sut = PacmanGame.Create(9990, 2, ui.Object);
            ICollisionSource collision = new TextCollisionSource("Dot,Apple,Key,InvincibleGhost");

            sut.Run(collision);

            ui.Verify(x => x.Display(It.IsAny<GameState>(), It.IsAny<string>()), Times.Exactly(4));
        }
    }
}