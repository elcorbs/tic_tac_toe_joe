using System;
using System.IO;
using FluentAssertions;
using NUnit.Framework;
using src;

namespace tests
{
    public class Tests
    {
        private StringWriter _textWriter;
        private TextWriter _tmp;

        [SetUp]
        public void Setup()
        {
            _tmp = Console.Out;
            _textWriter = new StringWriter();
            Console.SetOut(_textWriter);
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(_tmp);
        }

        [Test]
        public void EmptyBoardDisplayedAtTheBeginningOfAGame()
        {
            const string emptyBoard = "   " +
                                      "   " +
                                      "   ";
            Program.Main(new string[]{});
            _textWriter.ToString().Should().Be(emptyBoard);
        }
    }
}