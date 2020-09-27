using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace LastStandingSheep
{
    public sealed class RestartButton : MonoBehaviour, IPointerClickHandler
    {
        #region UnityMethods

        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}