using System;

namespace MoonActive.Managers
{
    public interface IEndGameHandler
    {
        public event Action OnGameEnded;
        public event Action OnAnimationCompleted;
    }
}