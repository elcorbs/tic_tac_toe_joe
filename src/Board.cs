namespace src
{
    public class Board
    {
        public Board(IBoardRepository repository)
        {
            State = new[]
            {
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '}
            };

            repository.Save(State);
        }

        public char[][] State { get; private set; }
    }
}