using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


namespace LastStandingSheep
{
    public sealed class RestartButton : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}