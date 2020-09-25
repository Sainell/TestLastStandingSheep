using UnityEngine;
using UnityEngine.EventSystems;


namespace LastStandingSheep
{
    public sealed class BackButton : MonoBehaviour, IPointerClickHandler
    {
        private Canvas _menuPrefab;
        private Canvas _interface;

        public void OnPointerClick(PointerEventData eventData)
        {
            _menuPrefab.enabled = false;
            _interface.enabled = true;
        }

        private void Awake()
        {
            _menuPrefab = gameObject.transform.parent.parent.GetComponent<Canvas>();
            _interface = GameObject.Find("GameInterface").GetComponent<Canvas>();
        }
    }
}
