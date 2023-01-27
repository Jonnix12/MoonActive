using System;
using MoonActive.Factorys;
using UnityEngine;

namespace MoonActive.Players
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private string _name;
        [SerializeField] private int _id;
        [SerializeField] private PlayerType _playerType;
        [SerializeField] private DiskType _diskType;
        
        public PlayerType PlayerType => _playerType;

        public DiskType DiskType => _diskType;

        public string Name => _name;

        public int ID => _id;

        public PlayerData(string name,int id,PlayerType playerType, DiskType diskType)
        {
            _name = name;
            _id = id;
            _playerType = playerType;
            _diskType = diskType;
        }

        public PlayerData()
        {
            
        }
    }
}