using MoonActive.Connect4;
using UnityEngine;

namespace MoonActive.Board
{
    public class BoardTest : MonoBehaviour
    {
        [SerializeField] private Disk _disk;
        private IGrid _grid;

        private void Start()
        {
            _grid = FindObjectOfType<ConnectGameGrid>();
            _grid.ColumnClicked += Test;
        }


        private void Test(int coulom)
        {
            Debug.Log(coulom);
            _grid.Spawn(_disk, coulom, 0);
        }

        private void OnDestroy()
        {
            _grid.ColumnClicked += Test;
        }
    }
}