using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class VibroToggleButton : MonoBehaviour, IPointerClickHandler
    {
        public static Action<bool> SwitchVibroEvent;
        private Toggle _vibroToggle;
        public void OnPointerClick(PointerEventData eventData)
        {
            SwitchVibroEvent?.Invoke(_vibroToggle.isOn);
        }
        private void Awake()
        {
            _vibroToggle = GetComponent<Toggle>();
        }
    }
}