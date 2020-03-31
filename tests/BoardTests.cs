using System;
using System.Linq;
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
        
        [SetUp]
        public void Setup()
        {
            _boardRepository = new Mock<IBoardRepository>();
        }

        [Test]
        public void BoardInitialisedAtStartOfGame()
        {
            var state =
                new[]
                {
                    new[] {' ', ' ', ' '},
                    new[] {' ', ' ', ' '},
                    new[] {' ', ' ', ' '}
                };
            _board = new Board(_boardRepository.Object);
            
            Console.WriteLine(state == _board.State);
            
            _boardRepository.Object.Save(state);
            
            _boardRepository.Verify(x => x.Save(state), Times.Once);
            
            //_board.State.Should()
            //    .BeEquivalentTo(state);
        }
    }
}