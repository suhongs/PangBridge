using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tools : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Canvas canvas = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
        }
    }
    Vector3 screenToWorldPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
    }
}