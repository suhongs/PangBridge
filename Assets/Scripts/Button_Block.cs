using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Block : MonoBehaviour
{
    // Start is called before the first frame update
    public Move_Block block;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        block.moveBlock();
    }

    private void OnCollisionExit(Collision collision)
    {
        block.backBlock();
    }
}
