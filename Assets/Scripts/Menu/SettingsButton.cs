using UnityEngine;
using UnityEngine.EventSystems;


namespace LastStandingSheep
{
    public sealed class SettingsButton : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        private Canvas _menuPrefab;
        private Canvas _interface;

        #endregion

        #region UnityMethods

        public void OnPointerClick(PointerEventData eventData)
        {
            OpenMenu();
        }

        private void Awake()
        {
            _menuPrefab = GameObject.Find("GameMenu").GetComponent<Canvas>();
            _interface = gameObject.transform.parent.GetComponent<Canvas>();

        }

        private void Start()
        {
            CharacterData.PlayerDie += OpenMenu;
            GameEventController.WinEvent += OpenMenu;
        }

        private void OnDestroy()
        {
            CharacterData.PlayerDie -= OpenMenu;
            GameEventController.WinEvent -= OpenMenu;
        }

        #endregion

        #region Methods

        private void OpenMenu()
        {
            _menuPrefab.enabled = true;
            _interface.enabled = false;
        }

        #endregion
    }
}