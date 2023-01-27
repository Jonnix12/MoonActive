
namespace MoonActive.Board
{
    public class BoardData
    {
        private readonly int[,] _gridData;
        private int _maxRaw;

        public int[,] GridData => _gridData;

        public BoardData(int colum,int raw)
        {
            _gridData = new int[colum, raw];
            _maxRaw = raw;
        }

        public bool AddDisk(int colum,int player,out int newRaw)
        {
            for (int raw = 0; raw < _maxRaw; raw++)
            {
                if (_gridData[colum, raw] != 0) continue;
                
                _gridData[colum, raw] = player;
                newRaw = raw;
                return true;
            }

            newRaw = -1;
            return false;
        }
    }
}