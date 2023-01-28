using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YonatanTools.Utilities.RectTransition;

namespace MoonActive.Managers
{
    [Serializable]
    public class EndGameHandler : IEndGameHandler
    {
        public event Action OnGameEnded;
        public event Action OnAnimationCompleted;

        [SerializeField] private RectTransform _visctoryScreen;
        [SerializeField] private Text _text;
        [SerializeField] private Button _restButton;
        [Header("Transitions")]
        [SerializeField] private RectTransform _midScreenPoint;
        [SerializeField] private TransitionPackSO _transition;

        public void DoVictoryAnimation(string playerName = null)
        {
            _text.text = playerName == null ? $"Draw!" : $"{playerName} Won!";
            
            _text.rectTransform.Transition(_midScreenPoint,_transition,OnAnimationCompleted);
        }
        
        public void EndGame(string winPlayer)
        {
            OnGameEnded?.Invoke();
            
            _restButton.onClick.AddListener(ResetGame);
            _restButton.gameObject.SetActive(true);
            
            DoVictoryAnimation(winPlayer);
        }

        private void ResetGame()
        {
            _restButton.onClick.RemoveListener(ResetGame);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}