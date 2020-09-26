using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LastStandingSheep
{
    public sealed class MusicToggleButton : MonoBehaviour, IPointerClickHandler
    {
        public static Action<bool> SwitchMusicEvent;
        private Toggle _musicToggle;
        public void OnPointerClick(PointerEventData eventData)
        {
            SwitchMusicEvent?.Invoke(_musicToggle.isOn);
        }
        private void Awake()
        {
            _musicToggle = GetComponent<Toggle>();
        }
    }
}