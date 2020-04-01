using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using src;

namespace tests
{
    public class AcceptanceTests
    {
        private Mock<TextWriter> _textWriter;
        private Mock<TextReader> _textReader;

        [SetUp]
        public void Setup()
        {
            _textReader = new Mock<TextReader>();
            _textWriter = new Mock<TextWriter>();

            Console.SetOut(_textWriter.Object);
            Console.SetIn(_textReader.Object);
        }

        [Test]
        public void EmptyBoardDisplayedAtTheBeginningOfAGame()
        {
            PlayGame();

            const string emptyBoard = "   \n" +
                                      "   \n" +
                                      "   ";
            AssertNextBoardReturnedIs(emptyBoard);
        }

        [Test]
        public void PlacingFirstMoveShowsCorrectBoard()
        {
            MockWriteToConsole("1,1");
            PlayGame();

            const string expectedBoard = "X  \n" +
                                         "   \n" +
                                         "   ";
            AssertNextBoardReturnedIs(expectedBoard);
        }

        [Test]
        public void PlacingFirstMoveAndOpponentMakesMove()
        {
            MockWriteToConsole("1,1");
            PlayGame();

            const string expectedBoard = "X  \n" +
                                         " O \n" +
                                         "   ";
            AssertNextBoardReturnedIs(expectedBoard);
        }

        private void AssertNextBoardReturnedIs(string board)
        {

            _textWriter.Verify(x => x.WriteLine(board));
        }

        private void MockWriteToConsole(string s)
        {
            _textReader.Setup(x => x.ReadLine()).Returns(s);
        }

        private static void PlayGame()
        {
            Program.Main(new string[] { });
        }
    }
}