using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform toolPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(toolPanel, Input.mousePosition))
        {
            Debug.Log("Drop tool");
        }
    }
}
