using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using src;

namespace tests
{
    [TestFixture]
    public class GameViewTests
    {
        private GameView _view;
        private static readonly char[][] EmptyBoard = {
            new[] {' ', ' ', ' '},
            new[] {' ', ' ', ' '},
            new[] {' ', ' ', ' '}
        };

        private IFixture _fixture;


        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
            _view = new GameView();
        }

        [Test]
        public void GameViewPrintsEmptyBoard()
        {
            GameView.PrintBoard(EmptyBoard).Should().Be(
                "   \n" +
                "   \n" +
                "   "
            );
        }

        [Test]
        public void GameViewCanReturnAPopulatedBoard()
        {
            var nonEmptyBoard = new []
            {
                new [] { RandomChar(), RandomChar(), RandomChar()},
                new [] { RandomChar(), RandomChar(), RandomChar()},
                new [] { RandomChar(), RandomChar(), RandomChar()}
            };
            GameView.PrintBoard(nonEmptyBoard).Should().Be(
                new string(nonEmptyBoard[0]) + "\n" +
                new string(nonEmptyBoard[1]) +  "\n" +
                new string(nonEmptyBoard[2])
            );
        }

        private char RandomChar()
        {
            return _fixture.Create<char>();
        }
    }
}