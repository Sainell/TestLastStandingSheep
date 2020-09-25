using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace LastStandingSheep
{
    public sealed class InLobbyButton : MonoBehaviour, IPointerClickHandler
    {
        private const int SCENE_LOBBY = 1;

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SCENE_LOBBY);
        }
    }
}
