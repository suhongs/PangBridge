using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Ballon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 defaultPosition;
    public bool isOnTrigger;
    void Start()
    {
        defaultPosition = transform.position;
        isOnTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
            transform.position += new Vector3(0, 1, 0) * 0.005f;
        else
            transform.position = defaultPosition;
    }
}
