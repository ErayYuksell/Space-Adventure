using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] //public olsada inspectorda gostermez
    public bool pressKey;
    public void OnPointerDown(PointerEventData eventData)
    {
        pressKey = true;   
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressKey = false;
    }
}
