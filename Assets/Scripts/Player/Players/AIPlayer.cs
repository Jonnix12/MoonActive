using MoonActive.Board;
using MoonActive.Connect4;
using MoonActive.Managers;
using UnityEngine;

namespace MoonActive.Players
{
    public class AIPlayer : BasePlayer
    {
        private IBoardHandler _boardHandler;
        private IDisk _iDisk;
        
        public AIPlayer(PlayerData playerData, Disk disk) : base(playerData, disk)
        {
            
        }
        
        public override void ExecuteTask(IGameManager data)
        {
            _boardHandler = data.GameHandler.BoardHandler;
        }

        public override void PlayerStartTurn()
        {
            int colum = Random.Range(0, 7);
            
            while (!_boardHandler.InsertDisk(colum, this,out _iDisk))
            {
                Debug.Log("AI Try aging");
                colum = Random.Range(0, 7);
            }
            
            _iDisk.StoppedFalling += CompletedAction;
        }

       
        public override void PlayerEndTurn()
        {
            _iDisk.StoppedFalling -= CompletedAction;
        }
    }
}