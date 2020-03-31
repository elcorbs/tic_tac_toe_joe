namespace src
{
    public interface IBoardRepository
    {
        void Save(char[][] state);
        char[][] Load();
    }
}