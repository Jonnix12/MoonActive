using System.Collections.Generic;
using MoonActive.Players;
using UnityEngine;

namespace MoonActive.GameConfig
{
    [CreateAssetMenu(fileName = "PlayersConfigSo", menuName = "ScriptableObjects/GameConfig/PlayersConfigSo")]
    public class PlayersConfigSo : ScriptableObject
    {
        [SerializeField] private List<PlayerData> _playerDatas = new List<PlayerData>();
        
        public List<PlayerData> PlayerDatas => _playerDatas;
    }
}