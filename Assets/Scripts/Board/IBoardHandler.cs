using System;
using MoonActive.Connect4;
using MoonActive.Players;

namespace MoonActive.Board
{
    public interface IBoardHandler
    {
        event Action<int> OnClickBoard;
        public DropPoint LastDropPoint { get; }
        
        bool InsertDisk(int newColum, BasePlayer player,out IDisk disk);
    }
}