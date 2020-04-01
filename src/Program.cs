using System;
using System.Linq;

namespace src
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var turn = 0;
            
            var board = new[]
            {
                0, 0, 0,
                0, -1, 0,
                0, 0, 0
            };

            while (true)
            {
                if (Opponent.IsBoardInTerminalState(board)) break;
                Console.WriteLine($"Turn: {++turn}");
                Console.WriteLine("Opponent's turn");
                var opponentMove = Opponent.NextMove(board, true);
                board[opponentMove] = 1;
                PrintBoard(board);
                
                if (Opponent.IsBoardInTerminalState(board)) break;
                Console.WriteLine("Player's turn");
                var playerMove = Opponent.NextMove(board, false);
                board[playerMove] = -1;
                PrintBoard(board);
            }

            /*var repository = new BoardRepository("board.txt");
            var controller = new GameController(repository);

            Console.WriteLine(GameView.PrintBoard(controller.Reset()));
            Console.ReadLine();
            var board = GameView.PrintBoard(controller.Move(1, 1));
            Console.WriteLine(board);*/
        }
    
        private static void PrintBoard(int[] board)
        {
            var chars = board.Select(x =>
                {
                    switch (x)
                    {
                        case 1: return 'O';
                        case -1: return 'X';
                        default: return ' ';
                    }
                }
            ).ToArray();

            Console.WriteLine(
                "  1 2 3\n" +
                $"1 {chars[0]} {chars[1]} {chars[2]}\n" +
                $"2 {chars[3]} {chars[4]} {chars[5]}\n" +
                $"3 {chars[6]} {chars[7]} {chars[8]}\n" 
            );
        }
    }
}
