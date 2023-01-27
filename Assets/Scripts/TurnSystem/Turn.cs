using System;
using MoonActive.Players;

namespace MoonActive.TurnSystem
{
    public class Turn : IDisposable
    {
        public event Action OnStartTurn;
        public event Action OnEndTurn;
    
        private BasePlayer _basePlayer;

        private bool _isActiveTurn;

        public bool IsActiveTurn => _isActiveTurn;

        public BasePlayer BasePlayer => _basePlayer;
    
        public Turn(BasePlayer basePlayer)
        {
            _basePlayer = basePlayer;
            OnStartTurn += _basePlayer.PlayerStartTurn;
            OnEndTurn += _basePlayer.PlayerEndTurn;
        }

        public void StartTurn()
        {
            OnStartTurn?.Invoke();
            _isActiveTurn = true;
        }

        public void EndTurn()
        {
            OnEndTurn?.Invoke();
            _isActiveTurn = false;
        }

        public void Dispose()
        {
            OnStartTurn -= _basePlayer.PlayerStartTurn;
            OnEndTurn -= _basePlayer.PlayerEndTurn;
        }
    }

}
