using System;

namespace src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var repository = new BoardRepository("board.txt");
            var controller = new GameController(repository);

            Console.WriteLine(GameView.PrintBoard(controller.Reset()));
            Console.ReadLine();
            var board = GameView.PrintBoard(controller.Move(1, 1));
            Console.WriteLine(board);
        }
    }
}
