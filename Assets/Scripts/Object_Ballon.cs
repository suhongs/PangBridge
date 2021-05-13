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
            transform.Translate(new Vector3(0, 0.002f, 0));
        }
        else if (GameManager.isGaming == false)
        {
            transform.Translate(new Vector3(0, 0, 0));
            if (!isFirst)
            {
                transform.position = defaultPosition;
                isFirst = true;
            }
            defaultPosition = transform.position;

        }
    }
}
