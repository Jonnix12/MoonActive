using System;
using System.Collections.Generic;
using MoonActive.Players;

namespace MoonActive.TurnSystem
{
    public class TurnHandler
    {
        public event Action OnSetNewCurrentTurn;
    
        private List<Turn> _turns;
        private int _currentTurnIndex;

        public BasePlayer CurrentBasePlayer => _turns[_currentTurnIndex].BasePlayer;

        public TurnHandler(List<BasePlayer> players)
        {
            _turns = new List<Turn>(players.Count);

            foreach (var player in players)
            {
                _turns.Add(new Turn(player));
            }
        }

        public void SetCurrentTurn(int turnIndex)
        {
            if(_turns[_currentTurnIndex].IsActiveTurn)
                _turns[_currentTurnIndex].EndTurn();
        
            _currentTurnIndex = turnIndex;

            _turns[_currentTurnIndex].StartTurn();
        
            OnSetNewCurrentTurn?.Invoke();
        }

        public void MoveToNextTurn()
        {
            if(_turns[_currentTurnIndex].IsActiveTurn)
                _turns[_currentTurnIndex].EndTurn();
        
            if (_currentTurnIndex >= _turns.Count - 1)
                _currentTurnIndex = 0;
            else
                _currentTurnIndex++;
        
            _turns[_currentTurnIndex].StartTurn();
        
            OnSetNewCurrentTurn?.Invoke();
        }
    }
}

