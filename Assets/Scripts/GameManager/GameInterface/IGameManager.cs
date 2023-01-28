using MoonActive.SequenceSystem;

namespace MoonActive.Managers
{
    public interface IGameManager
    {
        public IGameHandler GameHandler { get;}
        public IEndGameHandler EndGameHandler { get; }
    }
}