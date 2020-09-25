using UnityEngine;
using UnityEngine.EventSystems;


namespace LastStandingSheep
{
    public sealed class LobbySettingsButton : MonoBehaviour, IPointerClickHandler
    {
        private Canvas _menuPrefab;
        private Canvas _interface;

        public void OnPointerClick(PointerEventData eventData)
        {
            _menuPrefab.enabled = true;
            _interface.enabled = false;

        }

        private void Awake()
        {
            _menuPrefab = GameObject.Find("Settings").GetComponent<Canvas>();
            _interface = gameObject.transform.parent.parent.GetComponent<Canvas>();
        }
    }
}