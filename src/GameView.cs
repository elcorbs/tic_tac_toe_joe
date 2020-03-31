namespace src
{
    public class GameView
    {
        public static string PrintBoard(char[][] board)
        {
            return $"{board[0][0]}{board[0][1]}{board[0][2]}\n" +
                   $"{board[1][0]}{board[1][1]}{board[1][2]}\n" +
                   $"{board[2][0]}{board[2][1]}{board[2][2]}";
        }
    }
}