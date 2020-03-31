using System;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;
using FluentAssertions.Common;
using Moq;
using NUnit.Framework;
using src;

namespace tests
{
    [TestFixture]
    public class BoardTests
    {
        private Board _board;
        private Mock<IBoardRepository> _boardRepository;
        private static readonly char[][] emptyBoard = {
            new[] {' ', ' ', ' '},
            new[] {' ', ' ', ' '},
            new[] {' ', ' ', ' '}
        };

        [SetUp]
        public void Setup()
        {
            _boardRepository = new Mock<IBoardRepository>();
            _board = new Board(_boardRepository.Object);
        }

        [Test]
        public void AtStartOfGameInitialBoardIsSaved()
        {
            _boardRepository.Verify(x => x.Save(BoardsEqual(emptyBoard)), Times.Once);
        }

        [Test]
        public void CanGetEmptyBoardState()
        {
            _board.State.Should().BeEquivalentTo(emptyBoard);
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