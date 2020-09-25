using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace LastStandingSheep
{
    public sealed class NextButton : MonoBehaviour, IPointerClickHandler
    {
        private const int SCENE_NUMBER_1 = 0;
        public void OnPointerClick(PointerEventData eventData)
        {
            SceneManager.LoadScene(SCENE_NUMBER_1);
        }
    }
}