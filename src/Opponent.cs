using System;
using System.Linq;

namespace src
{
    public class Opponent
    {
        public Tuple<int, int> MakeMove(char[][] board)
        {
            var flatBoard = board[0].Concat(board[1]).Concat(board[2]).ToArray();

            for (var i = 0; i < 3; i++)
            {
                if (flatBoard[i] == 'O' && flatBoard[i + 3] == 'O' && flatBoard[i + 6] == ' ')
                    return IndexToCoordinate(i + 6);
                if (flatBoard[i] == 'O' && flatBoard[i + 3] == ' ' && flatBoard[i + 6] == 'O')
                    return IndexToCoordinate(i + 3);
                if (flatBoard[i] == ' ' && flatBoard[i + 3] == 'O' && flatBoard[i + 6] == 'O')
                    return IndexToCoordinate(i);
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

        private Tuple<int, int> IndexToCoordinate(int i)
        {
            return new Tuple<int, int>(i%3+1, i/3+1);
        }
    }
}