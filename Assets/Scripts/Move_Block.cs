using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Block : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 defaultPosition;
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveBlock()
    {
        transform.position += new Vector3(3, 0, 0);
    }

    public void backBlock()
    {
        transform.position += new Vector3(-3, 0, 0);
    }

}
