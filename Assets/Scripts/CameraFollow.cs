using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 velocity = Vector3.zero;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    public Vector3 offset;
    public float m_zoomSpeed = 2;
    public float m_zoomMax = 3;
    public float m_zoomMin = 20;

    void Start()
    {
        //offset = transform.position - target.position;
        offset = new Vector3(0, 7, -6);
    }

    void Zoom()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");
        if (offset.y <= m_zoomMax && t_zoomDirection > 0)
            return;
        if (offset.y >= m_zoomMin && t_zoomDirection < 0)
            return;

        offset.y -= t_zoomDirection * m_zoomSpeed;
        offset.z += t_zoomDirection * m_zoomSpeed;
    }

    private void Update()
    {
        Zoom();
        CameraMove();
    }
    void CameraMove()
    {
        if (Input.GetMouseButton(1))
        {
            float posX = Input.GetAxis("Mouse X");
            float posY = Input.GetAxis("Mouse Y");
            //transform.position += new Vector3(posX, 0, posY);
            transform.position += new Vector3(-posX, -posY, 0);
        }
    }
    void LateUpdate()
    {
        //Vector3 newPos = target.position + offset;
        //transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, SmoothFactor);
    }
}
