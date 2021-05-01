using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Ballon : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 defaultPosition = new Vector3(0, 0, 0);
    public bool isOnTrigger;
    public bool isFirst;
    void Start()
    {
        isFirst = true;
        isOnTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isFirst)
            {
                defaultPosition = transform.position;
                isFirst = false;
            }
            transform.position += new Vector3(0, 1, 0) * 0.005f;
        }
        else if (GameManager.isGaming == false)
        {

            if (!isFirst)
            {
                transform.position = defaultPosition;
                isFirst = true;
            }
            defaultPosition = transform.position;
        }
    }
}
