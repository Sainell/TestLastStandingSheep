using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class SoundsToggleButton : MonoBehaviour, IPointerClickHandler
    {
        public static Action<bool> SwitchSoundsEvent;
        private Toggle _soundsToggle;
        public void OnPointerClick(PointerEventData eventData)
        {
            SwitchSoundsEvent?.Invoke(_soundsToggle.isOn);
        }
        private void Awake()
        {
            _soundsToggle = GetComponent<Toggle>();
        }
    }
}