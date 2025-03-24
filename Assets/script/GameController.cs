using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Timer = 1.0f;         //타이머 변수를 선언한다.(float)(약수)
    public GameObject EnemyObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        Timer -= Time.deltaTime;            //시간을 매 프레이마다 감소 시킨다(델타 타임은 프레임 간격의 시간을 의미)

        if (Timer <= 0)                     //만약 타이머의 수치가 0이하로 내려갈 경우 (1초마다 동작되는 행동을 만들때)
        {
            Timer = 1;                          //다시 1초로 타이머를 초기화 시켜준다


            GameObject Temp = Instantiate(EnemyObject);
            Temp.transform.position = new Vector3(Random.Range(-8, 8),Random.Range(-4, 4), 0);


        }


        {
            if (Input.GetMouseButtonDown(0))                                    //마우스 버튼을 눌렀을때
            {
                RaycastHit hit;                                                 //물리 Hit 선언
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //카메라에서 Ray를 쏴서 3D 공간상의 물체를 확인다

                if (Physics.Raycast(ray, out hit))                           //Ray를 쐈을때 Hit되는 물체가 있으면
                {
                    if (hit.collider != null)                                       //물체가 존재하면
                    {
                  //Debug.Log($"hit : {hit.collider.name}");         //물체 이름을 출력한다
                        hit.collider.gameObject.GetComponent<Enemy>().CharacterHit(30);  //에너미 스크립트의 히트함수를 호출한다
                    }
                }
            }
        }
    }
}
