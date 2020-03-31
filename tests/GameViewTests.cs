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


        [SetUp]
        public void SetUp()
        {
            _view = new GameView();
        }

        [Test]
        public void GameViewPrintsEmptyBoard()
        {
            _view.PrintBoard(EmptyBoard).Should().Be(
                "   \n" +
                "   \n" +
                "   "
            );
        }
    }
}