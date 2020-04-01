using System;
using System.Linq;

namespace src
{
    public class Opponent
    {
        public static Tuple<int, int> MakeMove(char[][] board)
        {
            var flatBoard = board[0].Concat(board[1]).Concat(board[2]).ToArray();

            for (var i = 0; i < flatBoard.Length; i++)
            {
                if (flatBoard[i] != ' ') continue;

                var tempBoard = flatBoard.ToArray();
                tempBoard[i] = 'O';

                if (WonOnAColumn(tempBoard)) return IndexToCoordinate(i);

                if (WonOnRows(tempBoard)) return IndexToCoordinate(i);
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