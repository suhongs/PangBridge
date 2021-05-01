using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obejct_NotePass : MonoBehaviour
{
    public GameObject nodeParticle;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 colpoint = other.transform.position;
            //Quaternion colrotation = Quaternion.FromToRotation(-)

            Instantiate(nodeParticle, colpoint, transform.rotation);

            this.audioSource.Play();
            //Debug.Log("음표 작동");
        }
    }
}
