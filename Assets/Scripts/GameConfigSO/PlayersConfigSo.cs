using System.Collections.Generic;
using MoonActive.Players;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MoonActive.GameConfig
{
    [CreateAssetMenu(fileName = "PlayersConfigSo", menuName = "ScriptableObjects/PlayersConfigSo")]
    public class PlayersConfigSo : ScriptableObject
    {
        [SerializeField] private List<PlayerData> _playerDatas = new List<PlayerData>();
        
        public List<PlayerData> PlayerDatas => _playerDatas;


        [Button]
        private void AddNewPlayer()
        {
            _playerDatas.Add(new PlayerData());
        }

        [Button]
        public void ResetPlayerConfigSo()
        {
            _playerDatas.Clear();
        }
    }
}