using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemAutoDestory : MonoBehaviour
{
    private ParticleSystem me;
    // Start is called before the first frame update
    void Start()
    {
        me = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (me)
        {
            if(!me.IsAlive())
            {
                Destroy(gameObject);
            }
        }
    }
}
