using System;
using MoonActive.GameManagers;
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
        
        [SerializeField] private Text _text;
        [SerializeField] private TransitionPackSO _transition;
        [SerializeField] private Button _restButton;

        public void DoVictoryAnimation(string playerName = null)
        {
            _text.text = playerName == null ? $"Draw!" : $"{playerName} Won!";
            
            _text.rectTransform.Transition(_transition,OnAnimationCompleted);
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