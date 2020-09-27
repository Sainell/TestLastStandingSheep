using UnityEngine;
using UnityEngine.EventSystems;


namespace LastStandingSheep
{
    public sealed class LobbySettingsButton : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        private Canvas _menuPrefab;
        private Canvas _interface;

        #endregion


        #region UnityMethods

        public void OnPointerClick(PointerEventData eventData)
        {
            _menuPrefab.enabled = true;
            _interface.enabled = false;
        }

        private void Awake()
        {
            _menuPrefab = GameObject.Find("LobbySettings").GetComponent<Canvas>();
            _interface = gameObject.transform.parent.parent.GetComponent<Canvas>();
        }

        #endregion
    }
}