using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace LastStandingSheep
{
    public sealed class VibroToggleButton : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        public static Action<bool> SwitchVibroEvent;
        private Toggle _vibroToggle;

        #endregion


        #region UnityMethods

        public void OnPointerClick(PointerEventData eventData)
        {
            SwitchVibroEvent?.Invoke(_vibroToggle.isOn);
        }
        private void Awake()
        {
            _vibroToggle = GetComponent<Toggle>();
        }

        #endregion
    }
}