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
                0, 0, 0,
                0, 0, 0
            };

            while (true)
            {
                PrintBoard(board);

                if (Opponent.IsBoardInTerminalState(board)) break;
                
                Console.Write("Enter the square you'd like to play:");
                var playerMove = Console.ReadLine() ;
                var i = int.Parse(playerMove);
                board[i] = Opponent.PLAYER;
                
                if (Opponent.IsBoardInTerminalState(board)) break;
                
                var opponentMove = Opponent.NextMove(board, true);
                board[opponentMove] = Opponent.OPPONENT;
            }
            
            PrintBoard(board);

            /*var repository = new BoardRepository("board.txt");
            var controller = new GameController(repository);

            Console.WriteLine(GameView.PrintBoard(controller.Reset()));
            Console.ReadLine();
            var board = GameView.PrintBoard(controller.Move(1, 1));
            Console.WriteLine(board);*/
        }
    
        public static void PrintBoard(int[] board)
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
