using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    /*star의 고유 이벤트로 이관
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            gm.currentStar++;
            gm.UpdateUI();
        }
    }
    */
    
}
