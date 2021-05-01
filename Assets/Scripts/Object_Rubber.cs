using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Rubber : MonoBehaviour
{
    bool dir;
    // Start is called before the first frame update
    void Start()
    {
        dir = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 9)
            dir = false;
        if (transform.localScale.x < 3)
            dir = true;


        if (dir)
        {
            transform.localScale += new Vector3(1, 0, 0) * 0.005f;
            transform.localScale -= new Vector3(0, 1, 0) * 0.0005f;
        }
        else
        {
            transform.localScale -= new Vector3(1, 0, 0) * 0.005f;
            transform.localScale += new Vector3(0, 1, 0) * 0.0005f;
        }
    }
}
