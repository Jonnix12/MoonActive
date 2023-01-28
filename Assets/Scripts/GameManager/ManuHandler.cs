using System;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YonatanTools.Utilities.RectTransition;

namespace MoonActive.GameManagers
{
    [Serializable]
    public class ManuHandler
    {
        [SerializeField] private RectTransform _manu;
        [SerializeField] private Button _manuBotton;

        [SerializeField] private TransitionPackSO _closeTransition;
        [SerializeField] private TransitionPackSO _openTransition;
        
        public void StartOpenTransition()
        {
            _manu.Transition(_openTransition,OpenManu);
        }

        public void StartCloseTransition()
        {
            _manu.Transition(_closeTransition,CloseManu);
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
    }
}