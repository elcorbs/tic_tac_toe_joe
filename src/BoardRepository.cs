using System.IO;
using System.Linq;

namespace src
{
    public class BoardRepository : IBoardRepository
    {
        private readonly string _filePath;

        public BoardRepository(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(char[][] state)
        {
            var lines = state.Select(line => new string(line)).ToList();
            File.WriteAllLines(_filePath, lines);
        }

        public char[][] Load()
        {
            var lines = File.ReadAllLines(_filePath);
            return lines.Select(line => line.Select(c => c).ToArray()).ToArray() ;
        }
    }
}