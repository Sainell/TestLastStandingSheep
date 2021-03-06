﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LastStandingSheep
{
    public sealed class NextButton : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        private Canvas _lobbyMenu;
        private const int SCENE_NUMBER_1 = 1;

        #endregion


        #region UnityMethods

        public void OnPointerClick(PointerEventData eventData)
        {  
            SceneManager.LoadScene(SCENE_NUMBER_1);
            _lobbyMenu.enabled = false;
        }

        private void Awake()
        {
            _lobbyMenu = gameObject.transform.parent.parent.GetComponent<Canvas>();
        }

        #endregion
    }
}