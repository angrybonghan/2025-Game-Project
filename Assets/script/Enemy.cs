using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;           //체력을 선언 한다. (int)(정수)
    public float Timer = 1.0f;         //타이머 변수를 선언한다.(float)(약수)
    public int AttackPoint = 50;       //공격력를 선 언 한 다.

    //최초 프레임이 업데이트 되기 전 한번 실행 된다.
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;                        //이 스크립트가 실행 될 떄 100으로 고정




    }
    //게임 진행중인 매 프레임 마다 호출된다
    // Update is called once per frame
    void Update()
    {

        CharacterHealthUp();

        if (Input.GetKeyDown(KeyCode.Space))             //스페이스키를 눌렀을떄
          {
            Health -= AttackPoint;                      //체력 포인트를 공격 포인트만큼 감소시켜준다
                                                                //Hp=Hp-At
        }
        CheckDeath();


    }
    void CharacterHealthUp()
    {


        Timer -= Time.deltaTime;            //시간을 매 프레이마다 감소 시킨다(델타 타임은 프레임 간격의 시간을 의미)

        if (Timer <= 0)                     //만약 타이머의 수치가 0이하로 내려갈 경우 (1초마다 동작되는 행동을 만들때)
        {
            Timer = 1;                          //다시 1초로 타이머를 초기화 시켜준다
            Health += 10;                       //1초마다 체력을 10을 올려준다
        }




    }



public  void CharacterHit(int Damage)               //데미지를 받는 함수를 선언한다
    {
        Health -= Damage;                       //받은 공격력에 대한 체력을 감소시킨다

    }
    void CheckDeath()
    {

        if (Health <= 0)                      //체력이 0이하 일 경우
        {
            Destroy(gameObject);        //이 오브젝트를 파괴시킨다
        }



    }


}
