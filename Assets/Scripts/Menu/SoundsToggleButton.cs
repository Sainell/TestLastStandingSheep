using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace LastStandingSheep
{
    public sealed class SoundsToggleButton : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        public static Action<bool> SwitchSoundsEvent;
        private Toggle _soundsToggle;

        #endregion


        #region Methods

        public void OnPointerClick(PointerEventData eventData)
        {
            SwitchSoundsEvent?.Invoke(_soundsToggle.isOn);
        }
        private void Awake()
        {
            _soundsToggle = GetComponent<Toggle>();
        }

        #endregion
    }
}