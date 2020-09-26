using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class GameMenuSwitcher : MonoBehaviour
    {
        private GameObject _backButton;
        private GameObject _restartButton;
        private GameObject _nextButton;
        private GameObject _settingsButton;
        private GameObject _winText;
        private GameObject _lostText;
        private Canvas _canvasMenu;

        private void Awake()
        {           
            _backButton = transform.Find("Image/Back").gameObject;
            _restartButton =transform.Find("Image/Restart").gameObject;
            _nextButton = transform.Find("Image/Next").gameObject;
            _settingsButton = transform.Find("Image/Settings").gameObject;
            _winText= transform.Find("Image/Win").gameObject;
            _lostText= transform.Find("Image/Lost").gameObject;
            _canvasMenu = GetComponent<Canvas>();
            ResetMenu();
            CharacterData.PlayerDie += LostMenuSet;
            GameEventController.WinEvent += WinMenuSet;
        }

        private void WinMenuSet()
        {
            _backButton.SetActive(false);
            _nextButton.SetActive(true);
            _settingsButton.SetActive(false);
            _winText.SetActive(true);
            _lostText.SetActive(false);


        }
        private void LostMenuSet()
        {
            _backButton.SetActive(false);
            _nextButton.SetActive(false);
            _settingsButton.SetActive(false);
            _winText.SetActive(false);
            _lostText.SetActive(true);
        }
        private void ResetMenu()
        {
            _backButton.SetActive(true);
            _nextButton.SetActive(false);
            _settingsButton.SetActive(true);
            _winText.SetActive(false);
            _lostText.SetActive(false);
            _canvasMenu.enabled = false;
        }

        private void OnDestroy()
        {
            CharacterData.PlayerDie -= LostMenuSet;
            GameEventController.WinEvent -= WinMenuSet;
        }
    }
}