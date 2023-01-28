using System;
using UnityEngine;
using UnityEngine.UI;
using YonatanTools.Utilities.RectTransition;

namespace MoonActive.Managers
{
    [Serializable]
    public class ManuHandler : IDisposable
    {
        [Header("Manu ref")]
        [SerializeField] private RectTransform _manu;
        [SerializeField] private Button _manuBotton;
        [SerializeField] private Button _manuCloseBotton;

        [Header("Transitions")] 
        [SerializeField] private RectTransform _midScreenPoint;
        [SerializeField] private RectTransform _bottomScreenPoint;
        [SerializeField] private TransitionPackSO _closeTransition;
        [SerializeField] private TransitionPackSO _openTransition;

        public void Init()
        {
            _manuBotton.onClick.AddListener(StartOpenTransition);
            _manuCloseBotton.onClick.AddListener(StartCloseTransition);
        }

        public void StartOpenTransition()
        {
            OpenManu();
            _manu.Transition(_midScreenPoint,_openTransition);
        }

        public void StartCloseTransition()
        {
            _manu.Transition(_bottomScreenPoint,_closeTransition,CloseManu);
        }

        public void TurnOffMenuButton()
        {
            _manuBotton.gameObject.SetActive(false);
        }
        
        private void OpenManu()
        {
            _manu.gameObject.SetActive(true);
            _manuBotton.gameObject.SetActive(false);
        }

        private void CloseManu()
        {
            _manu.gameObject.SetActive(false);
            _manuBotton.gameObject.SetActive(true);
        }

        public void Dispose()
        {
            _manuBotton.onClick.RemoveAllListeners();
            _manuCloseBotton.onClick.RemoveAllListeners();
        }
    }
}