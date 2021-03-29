using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    //initialize 부분, 별도 스크립트 혹은 함수로 옮기는 것을 고려
    public GameObject[] stars;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Star"))
        {
            Destroy(other.gameObject);
            score = score + 1;
            scoreText.text = "<color=#ffffff>" + score + "/3 </color>";
        }
    }

    public void Setinitialize()
    {
        //별도 스크립트 혹은 함수로 옮기는 것을 고려
        stars = GameObject.FindGameObjectsWithTag("Star");
        for(int i = 0; i < stars.Length; i++)
        {
            Destroy(stars[i]); //
        }
        GameObject newstar = Resources.Load("Prefab/Star") as GameObject;
        GameObject starone = Instantiate(newstar, new Vector3(-19.91f, -9.03f, -0.03f), newstar.transform.rotation);
        GameObject startwo = Instantiate(newstar, new Vector3(-23.37f, -12.48f, -0.03f), newstar.transform.rotation);
        GameObject starthree = Instantiate(newstar, new Vector3(-27.07f, -16.11f, -0.03f), newstar.transform.rotation);

        score = 0;
        scoreText.text = "<color=#ffffff>" + score + "/3 </color>";
    }
}
