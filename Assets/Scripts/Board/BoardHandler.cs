using System;
using MoonActive.Connect4;
using MoonActive.GameConfig;
using MoonActive.Players;

namespace MoonActive.Board
{
    public class BoardHandler : IBoardHandler
    {
        public event Action<int> OnClickBoard; 

        private readonly IGrid _grid;
        private readonly BoardData _boardData;
        
        private DropPoint _lastDropPoint;

        public int[,] Board => _boardData.GridData;

        public DropPoint LastDropPoint => _lastDropPoint;
        
        public BoardHandler(IGrid grid,BoardConfigSO boardConfigSo)
        {
            _grid = grid;
            _boardData = new BoardData(boardConfigSo.ColumNumber, boardConfigSo.RawNumber);
            _grid.ColumnClicked += PlayerClick;
        }

        private void PlayerClick(int colum)
        {
           OnClickBoard?.Invoke(colum);
        }


        public bool InsertDisk(int newColum, BasePlayer player,out IDisk disk)
        {
            if (!_boardData.AddDisk(newColum, player.ID, out int newRaw))
            {
                disk = null;
                return false;
            }
            
            //Debug.Log($"Spawn disk at raw: {newRaw} colum: {newColum}");
            _lastDropPoint = new DropPoint(newRaw, newColum);
            disk = _grid.Spawn(player.Disk, newColum, newRaw);
            return true;
        }
    }
}