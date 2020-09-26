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

        private void OpenMenu()
        {
            _menuPrefab.enabled = true;
            _interface.enabled = false;
        }

        private void OnDestroy()
        {
            CharacterData.PlayerDie -= OpenMenu;
            GameEventController.WinEvent -= OpenMenu;
        }
    }
}