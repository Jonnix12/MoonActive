using UnityEngine;

namespace MoonActive.GameConfig
{
    [CreateAssetMenu(fileName = "BoardConfigSo", menuName = "ScriptableObjects/GameConfig/BoardConfigSo")]
    public class BoardConfigSO : ScriptableObject
    {
        [SerializeField] private int _columNumber;
        [SerializeField] private int _rawNumber;

        public int ColumNumber => _columNumber;

        public int RawNumber => _rawNumber;
    }
}