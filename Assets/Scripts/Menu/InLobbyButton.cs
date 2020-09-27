using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace LastStandingSheep
{
    public sealed class InLobbyButton : MonoBehaviour, IPointerClickHandler
    {
        #region Fields

        private const int SCENE_LOBBY = 1;


        #endregion


        #region UnityMethods

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SCENE_LOBBY);
        }

        #endregion
    }
}
