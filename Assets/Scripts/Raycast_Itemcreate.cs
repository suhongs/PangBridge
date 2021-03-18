using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast_Itemcreate : MonoBehaviour
{
    public GameObject SelectedItem;
    void Start()
    {
	SelectedItem = Resources.Load("SpringCylinder") as GameObject;
    }

    void Update()
    {
	if(Input.GetMouseButtonDown(0))
	{
		//Debug.Log("Raycast Creation");
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100f))
		{
			Vector3 hitPosition = hit.point;
			hitPosition.y = 0.5f;

			GameObject item = Instantiate(SelectedItem);
			item.transform.position = hitPosition;	
		}
	}
    }
}