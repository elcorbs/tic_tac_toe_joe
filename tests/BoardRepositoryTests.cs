using System.IO;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using src;

namespace tests
{
    public class BoardRepositoryTests
    {
        private IBoardRepository _boardRepository;
        private Fixture _fixture;
        private string _filePath;

        [SetUp]
        public void SetUp()
        {
            _filePath = "./board.txt";
            _boardRepository = new BoardRepository(_filePath);
            _fixture = new Fixture();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_filePath);
        }

        [Test]
        public void SaveCreatesAFile()
        {
            var board = _fixture.Create<char[][]>();
            _boardRepository.Save(board);
            File.Exists(_filePath).Should().BeTrue();
        }

        [Test]
        public void SaveTheDataCorrectly()
        {
            var board = _fixture.Create<char[][]>();
            _boardRepository.Save(board);

            var expectedSavedBoard = board.Select(line => new string(line)).ToList();

            File.ReadAllLines(_filePath).Should().BeEquivalentTo(expectedSavedBoard);
        }

        [Test]
        public void LoadsBoard()
        {
            var board = _fixture.Create<char[][]>();
            File.WriteAllLines(_filePath, board.Select(line => new string(line)));
            _boardRepository.Load().Should().BeEquivalentTo(board);
        }
    }
}