using System;

namespace src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = new BoardRepository("board.txt");
            var controller = new GameController(repository);
            var view = new GameView();

            var board = controller.Reset();
            Console.WriteLine(view.PrintBoard(board));
        }
    }
}
