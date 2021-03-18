using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tools : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject tool = null;
    Vector3 screenToWorldPosition;
    public int cost; //도구의 가격
    public GameManager gm;
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
        gm.CurrentCoin.text = (System.Convert.ToInt32(gm.CurrentCoin.text) - cost).ToString(); //마우스를 뗐을 때 cost만큼 현재 코인에서 차감
        Debug.Log("end drag");
    }
}