using MoonActive.Board;

namespace MoonActive.Managers
{
    public interface IGameHandler
    {
        public IBoardHandler BoardHandler { get; }
    }
}