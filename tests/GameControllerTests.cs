using FluentAssertions;
using Moq;
using NUnit.Framework;
using src;

namespace tests
{
    [TestFixture]
    public class GameControllerTests
    {
        private GameController _gameController;
        private Mock<IBoardRepository> _repository;
        private char[][] _emptyBoard;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IBoardRepository>();
            _gameController = new GameController(_repository.Object);
            _emptyBoard = new []{
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '}
            };
        }

        [Test]
        public void ResetReturnsEmptyBoard()
        {
            var board = _gameController.Reset();
            board.Should().BeEquivalentTo(_emptyBoard);
        }

        [Test]
        public void ResetSavesTheBoard()
        {
            _gameController.Reset();
            _repository.Verify(repo => repo.Save(BoardsEqual(_emptyBoard)), Times.Once);
        }

        [Test]
        public void MoveReturnsCorrectBoardForFirstTurn()
        {
            _repository.Setup(x => x.Load()).Returns(_emptyBoard);
            var firstTurnBoard = new []{
                new[] {'X', ' ', ' '},
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '}
            };
            var board = _gameController.Move(1, 1);
            board.Should().BeEquivalentTo(firstTurnBoard, options => options.WithStrictOrdering());
        }

        [Test]
        public void MoveReturnsCorrectBoardForDifferentFirstTurn()
        {
            _repository.Setup(x => x.Load()).Returns(_emptyBoard);
            var firstTurnBoard = new []{
                new char[] {' ', 'X', ' '},
                new char[] {' ', ' ', ' '},
                new char[] {' ', ' ', ' '}
            };
            var board = _gameController.Move(2, 1);
            board.Should().BeEquivalentTo(firstTurnBoard, options => options.WithStrictOrdering());
        }

        private static char[][] BoardsEqual(char[][] state)
        {
            return It.Is<char[][]>(s => s[0][0] == state[0][0]
                                        && s[0][1] == state[0][1]
                                        && s[0][2] == state[0][2]
                                        && s[1][0] == state[1][0]
                                        && s[1][1] == state[1][1]
                                        && s[1][2] == state[1][2]
                                        && s[2][0] == state[2][0]
                                        && s[2][1] == state[2][1]
                                        && s[2][2] == state[2][2]);
        }
    }
}