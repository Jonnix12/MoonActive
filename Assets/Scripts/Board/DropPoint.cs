namespace MoonActive.Board
{
    public struct DropPoint
    {
        private int _raw;
        private int _colum;

        public int Raw => _raw;

        public int Colum => _colum;

        public DropPoint(int raw,int colum)
        {
            _raw = raw;
            _colum = colum;
        }
    }
}