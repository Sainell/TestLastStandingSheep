using UnityEngine;
using UnityEngine.EventSystems;


namespace LastStandingSheep
{
    public sealed class SettingsButton : MonoBehaviour, IPointerClickHandler
    {
        private Canvas _menuPrefab;
        private Canvas _interface;

        public void OnPointerClick(PointerEventData eventData)
        {
            _menuPrefab.enabled = true ;
            _interface.enabled = false;
            
        }

        private void Awake()
        {
            _menuPrefab = GameObject.Find("GameMenu").GetComponent<Canvas>();
            _interface = gameObject.transform.parent.GetComponent<Canvas>();
        }
    }
}