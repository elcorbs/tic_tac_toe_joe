using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace src
{

    public class Opponent
    {
        public static int OPPONENT = 1;
        public static int EMPTY = 0;
        public static int PLAYER = -1;

        public static int MiniMax(int[] board, int depth, bool maximising)
        {
            
            if (IsBoardInTerminalState(board))
            {    
                return board.Sum();
            }

            if (maximising)
            {
                var bestVal = int.MinValue;
                for (var i = 0; i < 9; i++)
                {
                    if (board[i] != EMPTY) continue;
                    var newBoard = board.ToArray();
                    newBoard[i] = OPPONENT;
                    var value = MiniMax(newBoard, depth + 1, true);
                    bestVal = Math.Max(bestVal, value);
                }

                return bestVal;
            }
            else
            {
                var bestVal = int.MaxValue;
                for (var i = 0; i < 9; i++)
                {
                    if (board[i] != EMPTY) continue;
                    var newBoard = board.ToArray();
                    newBoard[i] = PLAYER;
                    var value = MiniMax(newBoard, depth + 1, false);
                    bestVal = Math.Min(bestVal, value);
                }

                return bestVal;
            }
        }

        public static int NextMove(int[] board, bool maximising=true)
        {
            var nextMove = -1;
            var bestScore = Opponent.MiniMax(board, 0, maximising);
            for (int i = 0; i < 9; i++)
            {
                if (board[i] != 0) continue;
                var newBoard = board.ToArray();
                newBoard[i] = OPPONENT;
                var score = MiniMax(newBoard, 0, maximising);
                if (score >= bestScore) nextMove = i;
                Program.PrintBoard(newBoard);
                Console.WriteLine(score);
            }
            

            return nextMove;
        }

        public static bool IsBoardInTerminalState(int[] board)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Math.Abs(board[i] + board[i + 3] + board[i + 6]) == 3)
                    return true;
                
                if (Math.Abs(board[i * 3] + board[i * 3 + 1] + board[i * 3 + 2]) == 3)
                    return true;
                
                if (Math.Abs(board[0] + board[4] + board[8]) == 3)
                    return true;

                if (Math.Abs(board[2] + board[4] + board[6]) == 3)
                    return true;
            }

            foreach (var i in board)
                if (i == EMPTY)
                    return false;
            
            return true;
        }
        
        public static Tuple<int, int> MakeMove(char[][] board)
        {
            var flatBoard = board[0].Concat(board[1]).Concat(board[2]).ToArray();

            for (var i = 0; i < flatBoard.Length; i++)
            {
                if (flatBoard[i] != ' ') continue;

                var tempBoard = flatBoard.ToArray();
                tempBoard[i] = 'O';

                if (CheckWin(tempBoard)) return IndexToCoordinate(i);
            }

            for (var i = 0; i < flatBoard.Length; i++)
            {
                if (flatBoard[i] == ' ')
                {
                    return IndexToCoordinate(i);
                }
            }

            return null;
        }

        private static bool CheckWin(char[] tempBoard)
        {
            return WonOnAColumn(tempBoard)
                   || WonOnRows(tempBoard)
                   || WonOnDiagonals(tempBoard);
        }

        private static bool WonOnDiagonals(char[] tempBoard)
        {
            return tempBoard[0] == 'O' && tempBoard[4] == 'O' && tempBoard[8] == 'O'
                   || tempBoard[2] == 'O' && tempBoard[4] == 'O' && tempBoard[6] == 'O';
        }

        private static bool WonOnRows(char[] tempBoard)
        {
            for (var i = 0; i < 3; i++)
            {
                var row = 3 * i;
                if (tempBoard[row] == 'O' && tempBoard[row + 1] == 'O' && tempBoard[row + 2] == 'O')
                    return true;
            }

            return false;
        }

        private static bool WonOnAColumn(char[] board)
        {
            for (var j = 0; j < 3; j++)
            {
                if (board[j] == 'O' && board[j + 3] == 'O' && board[j + 6] == 'O')
                    return true;
            }

            return false;
        }

        private static Tuple<int, int> IndexToCoordinate(int i)
        {
            return new Tuple<int, int>(i%3+1, i/3+1);
        }
    }
}