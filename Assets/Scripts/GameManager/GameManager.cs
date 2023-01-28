using System;
using System.Collections.Generic;
using MoonActive.Connect4;
using MoonActive.GameConfig;
using MoonActive.GameManagers;
using MoonActive.SequenceSystem;
using UnityEngine;

namespace MoonActive.Managers
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        /*
         * This is my game manager. Here sits all the logic of the sequence that runs the game. It is the only object that is MonoBehaviour
         */
        private static SequenceHandler<IGameManager> _sequenceHandler;
        /*
         * The game has two configuration files,
         * one for the players and one for the board
         */
        [Header("Game Config")]
        [SerializeField] private BoardConfigSO _boardConfig;
        [SerializeField] private List<PlayersConfigSo> _playersConfig;
        
        [Header("Scripts config")]
        [SerializeField] private EndGameHandler _endGameHandler;
        [SerializeField] private ManuHandler _manuHandler;
        
        private GameHandler _gameHandler;
        
        private IGrid _grid;
        private int _playerConfigIndex;
    
        public IGameHandler GameHandler => _gameHandler;
        public IEndGameHandler EndGameHandler => _endGameHandler;
    
        public void Awake()
        {
            _grid = FindObjectOfType<ConnectGameGrid>();
            _manuHandler.Init();
            _manuHandler.StartOpenTransition();
        }
    
        public void SetPlayerConfigIndex(int configIndex)
        {
            if (configIndex >= _playersConfig.Count || configIndex < 0)
            {
                throw new Exception("Game manager: playerConfig index is out of range");
            }
    
            _playerConfigIndex = configIndex;
        }
    
        public void StartNewGame()
        {
            _gameHandler = new GameHandler(_grid,_playersConfig[_playerConfigIndex],_boardConfig);
            _sequenceHandler.StartAll(this);
            _manuHandler.StartCloseTransition();
    
            _gameHandler.OnConnectFound += _endGameHandler.EndGame;
            
            _gameHandler.StartGame();
        }
        
        public static void Register(ISequenceOperation<IGameManager> operation)
        {
            _sequenceHandler ??= new SequenceHandler<IGameManager>();
                
            _sequenceHandler.Register(operation);
        }

        private void OnDestroy()
        {
            _manuHandler.Dispose();
            _sequenceHandler.Reset();
            _gameHandler.OnConnectFound -= _endGameHandler.EndGame;
            _gameHandler.Dispose();
        }
    }
}

