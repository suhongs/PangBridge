using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tool_Canvas : MonoBehaviour
{
    public GameObject Tool = null; 
    public GameObject ArrowContainer=null; // 이동화살표 컨테이너


    public void MoveBtnClick()
    {
        ArrowContainer.SetActive(true);
    }
    public void RotateBtnClick()
    {

    }
    public void SellBtnClick()
    {

    }
    public void CopyBtnClick()
    {

    }
}
