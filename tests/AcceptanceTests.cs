using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using src;

namespace tests
{
    public class AcceptanceTests
    {
        private StringWriter _textWriter;
        private TextWriter _tmpWriter;
        private TextReader _tmpReader;

        [SetUp]
        public void Setup()
        {
            _tmpWriter = Console.Out;
            _tmpReader = Console.In;
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_tmpWriter);
            Console.SetIn(_tmpReader);
        }

        [Test]
        public void EmptyBoardDisplayedAtTheBeginningOfAGame()
        {
            const string emptyBoard = "   \n" +
                                      "   \n" +
                                      "   \n";
            ResetTextWriter();
            Program.Main(new string[]{});
            _textWriter.ToString().Should().Be(emptyBoard);
        }

        [Test]
        public void PlacingFirstMoveShowsCorrectBoard()
        {
            Program.Main(new string[]{});
            ResetTextWriter();
            WriteToConsole("1,1");
            const string board = "X  \n" + 
                                 "   \n" +
                                 "   \n";
            _textWriter.ToString().Should().Be(board);
        }

        private void WriteToConsole(string s)
        {
            Console.SetIn(new StringReader(s));
        }

        private void ResetTextWriter()
        {
            _textWriter = new StringWriter();
            Console.SetOut(_textWriter);
        }
    }
}