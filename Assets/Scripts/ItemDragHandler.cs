using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameManager gm;

    private RectTransform rectTransform;
    //bool rotateMode = false;
    public Canvas canvas;
    private Vector3 prevPos;

    public GameObject ToolUI;
    public Vector2 dragOffset;

    // Start is called before the first frame update
    void Start()
    {
        ToolUI = GameObject.FindWithTag("ToolUI");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rectTransform = GetComponent<RectTransform>();
    }
    

    public void OnPointerDown(PointerEventData eventData)
    {
        gm.rotateMode = true;
        prevPos = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOffset = eventData.position - (Vector2)transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gm.rotateMode = false;
        rectTransform.position = prevPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
        /*
        float mZCoord;
        if (rotateMode)
        {
            mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = mZCoord;

            Vector3 dir = Camera.main.ScreenToWorldPoint(mousePoint) - gm.SelectedTool.transform.position;

            float angle = Vector3.Angle(new Vector3(dir.x, dir.y, 0), new Vector3(1, 0, 0));

            if ((dir.x > 0 && dir.y < 0) || dir.x < 0 && dir.y < 0)
                angle = -angle;
            gm.SelectedTool.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
        */

        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        rectTransform.position = eventData.position - dragOffset;
    }
}
