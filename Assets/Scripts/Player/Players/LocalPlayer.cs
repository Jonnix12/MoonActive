using MoonActive.Board;
using MoonActive.Connect4;
using MoonActive.Gamemanagers;

namespace MoonActive.Players
{
    public class LocalPlayer : BasePlayer
    {
        private IBoardHandler _boardHandler;
        private IDisk _IDisk;
        
        public LocalPlayer(PlayerData playerData, Disk disk) : base(playerData, disk)
        {
            
        }
        
        public override void ExecuteTask(IGameManager data)
        {
            _boardHandler = data.BoardHandler;
        }
        
        public override void PlayerStartTurn()
        {
            _boardHandler.OnClickBoard += PlayerAction;
        }

        public override void PlayerEndTurn()
        {
            _IDisk.StoppedFalling -= CompletedAction;
        }

        private void PlayerAction(int columClick)
        {
            if (!_boardHandler.InsertDisk(columClick, this, out _IDisk)) return;
            
            _boardHandler.OnClickBoard -= PlayerAction;
            _IDisk.StoppedFalling += CompletedAction;
        }
    }
}