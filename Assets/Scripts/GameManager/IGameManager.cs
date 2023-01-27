using MoonActive.Board;

namespace MoonActive.Gamemanagers
{
    public interface IGameManager
    {
        public IBoardHandler BoardHandler { get; }
    }
}