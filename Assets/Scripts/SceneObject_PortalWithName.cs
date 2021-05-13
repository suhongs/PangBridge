using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject_PortalWithName : MonoBehaviour
{
    GameObject ResetPortal;
    public bool slowdown = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
            ResetPortal = GameObject.Find(this.gameObject.name + "Out");
            if (ResetPortal != null)
            {
                rigid.transform.position = new Vector3(ResetPortal.transform.position.x, ResetPortal.transform.position.y, 0f);
                if(slowdown)
                {
                    rigid.velocity = new Vector3(0, 0, 0);
                }
                //float speed = rigid.velocity.magnitude * 50;
                //Vector3 inNormal = Vector3.Normalize(transform.position - rigid.transform.position);
                //rigid.transform.position = new Vector3(ResetPortal.transform.position.x, ResetPortal.transform.position.y, 0f);
                //진행하는 방향이 바뀌는 문제가 있어서 진입 각도와 같은 방향으로 나가도록 설정? 혹은 오브젝트의 Rotation을 기준으로 이를 설정하는 방법도 고려해봐야?
                //1안: 포탈 타고 가면 속도를 아예 0으로 초기화
                //rigid.velocity = new Vector3(0, 0, 0);
                //2안: 포탈 타고 가면 기존에 받던 방향으로 힘을 그대로 주기
                //Debug.Log(speed);
                //rigid.velocity = new Vector3(0, 0, 0);
                //rigid.AddForce(inNormal * speed); // 속도를 velocity.magnitude로 줬더니 영향이 없는 것에 가까운 결과를 확인하여 *100, 정밀한 결과를 위해선 별도 개선 필요

            }
            else
            {
                //실패 이펙트만 출력
            }
        }
    }

        /*
        void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.tag == "Player")
            {
                Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
                ResetPortal = GameObject.Find(this.gameObject.name + "Out");
                if (ResetPortal != null)
                {
                    float speed = rigid.velocity.magnitude * 50;
                    Vector3 inNormal = Vector3.Normalize(transform.position - rigid.transform.position);
                    rigid.transform.position = new Vector3(ResetPortal.transform.position.x, ResetPortal.transform.position.y, 0f);
                    //진행하는 방향이 바뀌는 문제가 있어서 진입 각도와 같은 방향으로 나가도록 설정? 혹은 오브젝트의 Rotation을 기준으로 이를 설정하는 방법도 고려해봐야?
                    //1안: 포탈 타고 가면 속도를 아예 0으로 초기화
                    //rigid.velocity = new Vector3(0, 0, 0);
                    //2안: 포탈 타고 가면 기존에 받던 방향으로 힘을 그대로 주기
                    //Debug.Log(speed);
                    //rigid.velocity = new Vector3(0, 0, 0);
                    //rigid.AddForce(inNormal * speed); // 속도를 velocity.magnitude로 줬더니 영향이 없는 것에 가까운 결과를 확인하여 *100, 정밀한 결과를 위해선 별도 개선 필요

                }
                else
                {
                    //실패 이펙트만 출력
                }
            }
        }
        */
}
