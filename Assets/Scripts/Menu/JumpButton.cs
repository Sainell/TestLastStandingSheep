using System;
using UnityEngine;
using UnityEngine.EventSystems;


public sealed  class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Fields

    public static Action<float> JumpButtonEvent;

    #endregion


    #region UnityMethods

    public void OnPointerDown(PointerEventData eventData)
    {
        JumpButtonEvent?.Invoke(1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        JumpButtonEvent?.Invoke(0);
    }

    #endregion

}
