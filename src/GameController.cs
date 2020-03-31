namespace src
{
    public class GameController
    {
        private IBoardRepository _repository;
        private Board _board;

        public GameController(IBoardRepository repository)
        {
            _repository = repository;
            _board = new Board();
        }
        public char[][] Reset()
        {
            _board.State = new [] {
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '},
                new[] {' ', ' ', ' '}
            };
            _repository.Save(_board.State);
            return _board.State;
        }

        public char[][] Move(int x, int y)
        {
            _board.State = _repository.Load();
            _board.State[y-1][x-1] = 'X';
            _repository.Save(_board.State);
            return _board.State;
        }
    }
}