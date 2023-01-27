using System;
using MoonActive.Connect4;
using MoonActive.Gamemanagers;
using MoonActive.SequenceSystem;

namespace MoonActive.Players
{
    public abstract class BasePlayer : IPlayer , ISequenceOperation<IGameManager>
    {
        public event Action OnCompletedAction;
    
        private PlayerData _data;
        private Disk _disk;
    
        public Disk Disk => _disk;

        public string Name => _data.Name;

        public int ID => _data.ID;

        public PlayerData Data => _data;

        protected BasePlayer(PlayerData playerData,Disk disk)
        {
            _data = playerData;
            _disk = disk;
            GameManager.Instance.Register(this);
        }
    
        public abstract void ExecuteTask(IGameManager data);

        public abstract void PlayerStartTurn();

        public virtual void PlayerUpdateTurn()
        {
        
        }
    
        public abstract void PlayerEndTurn();

        protected void CompletedAction()
        {
            OnCompletedAction?.Invoke();
        }
    }
}



