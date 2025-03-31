using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlpyerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                  //이동ㅅㅗㄱ도 
    public Rigidbody rb;
    public float jumpForce = 5.0f;

    public bool isGround = true;

    public int coinCount = 0;
    public int totalCoins = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //속도값으로 직접 이동
        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);



        if (Input.GetButtonDown("Jump") && isGround)            //&& 두값이 트루일떄 (보통 스페이스바 와 땅위에 있을 떄)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  //위쪽으로 설정한 힘만큼 강체에 힘을 전달한다
            isGround = false;                       //점프를 하는순간 땅에서 떨어졌기 떄문에 폴스 라고 한다.
        }



    }


    void OnCollisionEnter(Collision collision)      //충돌이 일어났을떄 호출되는 함수
    {
        if (collision.gameObject.tag == "Ground")            //충돌이 일어난 불(물)체의 태그가 그라운드인경우
        {
            isGround = true;                         //땅과 충돌했을떄 트루로 변경해준다

        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) ;
        {
            coinCount++;
            Destroy(other.gameObject);                                  //코인 오브젝트를 제거한다
            Debug.Log($"코인 수집:{coinCount}/{totalCoins}");               //수집한 코인 1/5 식으로 콘솔 로그에 표현한다
        }
        if(other.CompareTag("Door") && coinCount >= totalCoins)             // zhdls wjs
        {
            Debug.Log("게임 클리어");

        }
    }
}
