using NUnit.Framework;

namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmptyBoardDisplayedAtTheBeginningOfAGame()
        {
            var emptyBoard = "   " +
                             "   " +
                             "   ";
        }
    }
}