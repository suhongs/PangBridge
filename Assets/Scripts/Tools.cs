using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tools : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject tool = null;
    Vector3 screenToWorldPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        screenToWorldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        Instantiate(tool, screenToWorldPosition, tool.transform.rotation);
    }

    public void OnDrag(PointerEventData eventData)
    {
        screenToWorldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        tool.transform.position = screenToWorldPosition;
        Debug.Log("dragging");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        screenToWorldPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        tool.transform.position = screenToWorldPosition;
        Debug.Log("end drag");
    }
}