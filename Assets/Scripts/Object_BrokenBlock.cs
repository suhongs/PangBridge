using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_BrokenBlock : MonoBehaviour
{
    private int collisioncheck;
    private Vector3 defaultPosition;
    private Vector3 defaultScale;
    private bool isGameStarted;
    private GameObject nodeParticleOne;
    private GameObject nodeParticleTwo;
    private GameObject nodeParticleThree;
    private AudioSource audioSource;

    //3회 hit시 사라지는 block

    // Start is called before the first frame update
    void Start()
    {
        collisioncheck = 0;
        isGameStarted = true;
        defaultScale = transform.localScale;

        nodeParticleOne = Resources.Load("Prefab/Particles/Cube_Collision_Blue") as GameObject;
        nodeParticleTwo = Resources.Load("Prefab/Particles/Cube_Collision_Yellow") as GameObject;
        nodeParticleThree = Resources.Load("Prefab/Particles/Cube_Collision_Red") as GameObject;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                defaultPosition = transform.position;
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                transform.position = defaultPosition;
                transform.localScale = defaultScale;
                gameObject.GetComponent<BoxCollider>().isTrigger = false;
                gameObject.GetComponent<MeshRenderer>().material = Resources.Load("Material/Skyblue") as Material;
                collisioncheck = 0;
                isGameStarted = true;
            }
            defaultPosition = transform.position; //게임 중이 아닐 땐 지속적으로 위치 갱신
        }
    }

    
    void OnCollisionEnter(Collision other)
    {
    //Debug.Log("collision");
        if (other.gameObject.tag == "Player")
        {
            //Vector3 colpoint = other.transform.position;
            Vector3 colpoint = other.contacts[0].point;
            this.audioSource.Play();
            //Quaternion colrotation = Quaternion.FromToRotation(-)

            collisioncheck++;
            //collision이 횟수에 따라 파랑->빨강->파괴 순서로 진행
            if (collisioncheck == 1)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                Instantiate(nodeParticleTwo, new Vector3(colpoint.x, colpoint.y, -0.2f), nodeParticleTwo.transform.rotation);
            }
            else if (collisioncheck == 2)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Instantiate(nodeParticleThree, new Vector3(colpoint.x, colpoint.y, -0.2f), nodeParticleThree.transform.rotation);
            }
            if (collisioncheck > 2)
            {
                gameObject.GetComponent<BoxCollider>().isTrigger = true; //접촉 시 통과되도록
                Instantiate(nodeParticleOne, new Vector3(colpoint.x, colpoint.y, -0.2f), nodeParticleOne.transform.rotation);
                transform.localScale = new Vector3(0, 0, 0);
                //gameObject.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}
