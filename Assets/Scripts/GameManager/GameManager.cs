using System.Collections.Generic;
using MoonActive.Algorithms;
using MoonActive.Board;
using MoonActive.Connect4;
using MoonActive.Factorys;
using MoonActive.Players;
using MoonActive.SequenceSystem;
using MoonActive.Singleton;
using MoonActive.TurnSystem;
using UnityEngine;
using PlayersConfigSo = MoonActive.GameConfig.PlayersConfigSo;

namespace MoonActive.Gamemanagers
{
    public class GameManager : MonoSingleton<ISequenceHandler<IGameManager>>, IGameManager , ISequenceHandler<IGameManager>
    {
        [SerializeField] private PlayersConfigSo _playersConfigSo;

        private SequenceHandler<IGameManager> _sequenceHandler;

        private VictoryAlgorithm _victoryAlgorithm;
        private PlayerFactory _playerFactory;
        private TurnHandler _turnHandler;
        private BoardHandler _boardHandler;

        private List<BasePlayer> _players;
        
        public IBoardHandler BoardHandler => _boardHandler;

        private void Start()
        {
            _playerFactory = new PlayerFactory();
            _boardHandler = new BoardHandler(FindObjectOfType<ConnectGameGrid>());
            _victoryAlgorithm = new VictoryAlgorithm(4);
            
            _players = _playerFactory.GetPlayers(_playersConfigSo.PlayerDatas.ToArray());
            _turnHandler = new TurnHandler(_players);
            
            foreach (var player in _players)
            {
                player.OnCompletedAction += MoveToNextTurn;
            }
            
            _sequenceHandler.StartAll(this);
            
            _turnHandler.SetCurrentTurn(0);
        }
        
        public void Register(ISequenceOperation<IGameManager> operation)
        {
            _sequenceHandler ??= new SequenceHandler<IGameManager>();
            
            _sequenceHandler.Register(operation);
        }

        private void MoveToNextTurn()
        {
            int result = _victoryAlgorithm.CheckForVictory(_boardHandler.Board, _boardHandler.LastDropPoint,
                _turnHandler.CurrentBasePlayer.ID);

            Debug.Log(result);
            
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