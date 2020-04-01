using System;
using FluentAssertions;
using NUnit.Framework;
using src;

namespace tests
{
    [TestFixture]
    public class OpponentTests
    {
        private Opponent _opponent;

        [SetUp]
        public void SetUp()
        {
            _opponent = new Opponent();
        }

        [Test]
        public void OpponentPlaysInLastSpace()
        {
            var board = new[]
            {
                new[] {'X', 'X', 'O'},
                new[] {'O', 'X', 'X'},
                new[] {'X', ' ', 'O'}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(2, 3));
        }

        [Test]
        public void OpponentPlaysInLastSpaceTwo()
        {
            var board = new[]
            {
                new[] {'X', ' ', 'O'},
                new[] {'O', 'X', 'X'},
                new[] {'X', 'X', 'O'}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(2, 1));
        }

        [Test]
        public void OpponentMakesWinningFirstColumn()
        {
            var board = new[]
            {
                new[] {'O', ' ', ' '},
                new[] {'O', 'X', ' '},
                new[] {' ', 'X', ' '}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(1, 3));
        }

        [Test]
        public void OpponentMakesWinningMoveEndColumn()
        {
            var board = new[]
            {
                new[] {' ', ' ', 'O'},
                new[] {'X', ' ', 'O'},
                new[] {' ', 'X', ' '}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(3, 3));
        }

        [Test]
        public void OpponentMakesWinningMoveMiddleColumnBottomRow()
        {
            var board = new[]
            {
                new[] {' ', 'O', 'X'},
                new[] {'X', 'O', 'X'},
                new[] {' ', ' ', ' '}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(2, 3));
        }

        [Test]
        public void OpponentMakesWinningMoveMiddleColumnMiddleRow()
        {
            var board = new[]
            {
                new[] {' ', 'O', 'X'},
                new[] {'X', ' ', 'X'},
                new[] {' ', 'O', ' '}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(2, 2));
        }

        [Test]
        public void OpponentMakesWinningMoveMiddleColumnFirstRow()
        {
            var board = new[]
            {
                new[] {' ', ' ', 'X'},
                new[] {'X', 'O', 'X'},
                new[] {' ', 'O', ' '}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(2, 1));
        }

        [Test]
        public void OpponentCannotMakeWinningMove()
        {
            var board = new[]
            {
                new[] {'O', 'X', 'O'},
                new[] {'O', ' ', 'O'},
                new[] {'X', 'X', ' '}
            };

            _opponent.MakeMove(board).Should().BeEquivalentTo(new Tuple<int, int>(3, 3));
        }
    }
}