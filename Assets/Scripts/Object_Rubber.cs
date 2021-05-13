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
        if (GameManager.isGaming)
        {
            if (transform.localScale.x > 3)
                dir = false;
            if (transform.localScale.x < 1)
                dir = true;


            if (dir)
            {
                transform.localScale += new Vector3(1, 0, 0) * 0.005f;
            }
            else
            {
                transform.localScale -= new Vector3(1, 0, 0) * 0.005f;
            }
        }
    }
}
