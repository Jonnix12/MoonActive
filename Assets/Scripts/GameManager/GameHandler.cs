using System;
using System.Collections.Generic;
using MoonActive.Algorithms;
using MoonActive.Board;
using MoonActive.Connect4;
using MoonActive.Factorys;
using MoonActive.GameConfig;
using MoonActive.Players;
using MoonActive.TurnSystem;

namespace MoonActive.Managers
{
    [Serializable]
    public class GameHandler : IGameHandler
    {
        public event Action<string> OnConnectFound;
        
        private VictoryAlgorithm _victoryAlgorithm;
        private TurnHandler _turnHandler;
        private BoardHandler _boardHandler;

        private List<BasePlayer> _players;
        
        public IBoardHandler BoardHandler => _boardHandler;

        public GameHandler(IGrid grid, PlayersConfigSo playersConfigSo, BoardConfigSO boardConfigSo)
        {
            _boardHandler = new BoardHandler(grid,boardConfigSo);
            
            _victoryAlgorithm = new VictoryAlgorithm(4);
            
            _players = PlayerFactory.GetPlayers(playersConfigSo.PlayerDatas.ToArray());
            _turnHandler = new TurnHandler(_players);
            
            foreach (var player in _players)
            {
                player.OnCompletedAction += MoveToNextTurn;
            }
        }

        public void StartGame()
        {
            _turnHandler.SetCurrentTurn(0);
        }

        private void MoveToNextTurn()
        {
            int result = _victoryAlgorithm.CheckForVictory(_boardHandler.Board, _boardHandler.LastDropPoint,
                _turnHandler.CurrentBasePlayer.ID);

            if (result != -1)
            {
                if (result == 0)
                {
                    OnConnectFound?.Invoke(null);
                    return;                    
                }
                
                OnConnectFound?.Invoke(_turnHandler.CurrentBasePlayer.Name);
                return;
            }
            
            _turnHandler.MoveToNextTurn();
        }

        public void Dispose()
        {
            foreach (var player in _players)
            {
                player.OnCompletedAction -= MoveToNextTurn;
            }
        }
    }
}