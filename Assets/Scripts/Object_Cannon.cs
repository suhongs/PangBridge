using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Cannon : MonoBehaviour
{
    private AudioSource audiosource;
    private GameManager gm;
    Camera cam = null;
    [SerializeField] GameObject CannonDir = null;
    private GameObject player = null;
    private GameObject effectpos;
    public GameObject sound;
    private AudioSource audio2;
    
    [SerializeField]
    GameObject shootEffect;
    private Vector3 mouseDir;
    private Vector3 boxColliderSize;
    private bool isGameStarted;
    private Rigidbody rb;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
        boxColliderSize = GetComponent<BoxCollider>().size;
        audiosource = GetComponent<AudioSource>();
        audio2 = sound.GetComponent<AudioSource>();
        effectpos = transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if(gm.isCannon) //포구 회전
        {
            CannonDir.transform.RotateAround(transform.position, Vector3.forward, 75f * Time.deltaTime);

        }
        if(gm.isCannon)
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(player != null)
                {
                    player.GetComponent<Rigidbody>().velocity = CannonDir.transform.forward * 20f;
                    
                    player.GetComponent<Rigidbody>().useGravity = true;
                    //StartCoroutine("Cooltime");
                    gameObject.GetComponent<BoxCollider>().size = boxColliderSize;
                    gm.isCannon = false;

                    StartCoroutine("AddEffect");
                    Instantiate(shootEffect, player.transform.position, Quaternion.identity);
                    audio2.Play();
                }
            }
        }

        if (GameManager.isGaming)
        {
            if (isGameStarted)
            {
                isGameStarted = false;
            }
        }
        else if (GameManager.isGaming == false)
        {
            if (!isGameStarted) //게임이 시작된 적이 있는데 정지됬다면
            {
                gameObject.transform.rotation = Quaternion.identity;
                isGameStarted = true;
                gameObject.GetComponent<BoxCollider>().size = boxColliderSize;
                gm.isCannon = false;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            audiosource.Play(); //사운드 실행
            player = other.gameObject;
            //플레이어 세팅 초기화
            player.GetComponent<Rigidbody>().useGravity = false; //플레이어의 중력을 끄고
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.transform.position = gameObject.transform.position;
            gameObject.GetComponent<BoxCollider>().size = new Vector3(0f, 0f, 0f);
            gm.isCannon = true;
        }
    }
    IEnumerator Cooltime()
    {
        
        yield return new WaitForSeconds(2f);
    }
    IEnumerator AddEffect()
    {
        
        yield return new WaitForSeconds(2f);
    }
}
