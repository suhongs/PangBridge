using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageComplete : MonoBehaviour
{
    public GameManager gm;
    public bool isCleared;
    GameObject starImage1;
    GameObject starImage2;
    public Sprite blankStar;
    public Sprite star;

    // Start is called before the first frame update
    void Start()
    {
        starImage1 = GameObject.Find("scoreStar2");
        starImage2 = GameObject.Find("scoreStar3");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.isCleared == true)
        {
            if(gm.currentStar == 1)
            {
                starImage1.GetComponent<Image>().sprite = blankStar;
            }
            if(gm.currentStar == 3)
            {
                starImage2.GetComponent<Image>().sprite = star;
            }
            gm.isCleared = false;
        }
    }
}
