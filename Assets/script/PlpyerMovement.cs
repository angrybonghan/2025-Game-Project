using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlpyerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                  //이동ㅅㅗㄱ도 
    public Rigidbody rb;
    public float jumpForce = 7.0f;
    [Header("점프 개선 설정")]
    public float fallMultiplier = 2.5f;     //하강 중력 배율
    public float lowJumpMulitipilier = 2.0f;        //짧은 점프 배율
    [Header("지연 감지 설정")]
    public float coyoteTime = 0.15f;
    public float coyoteTimeCounter;
    public bool realGrounded = true;
    [Header("글라이더 설정")]
    public GameObject gliderObjrct;
    public float gliderFallSpeed = 1.0f;
    public float glidermoveSpeed = 7.0f;
    public float gliderMaxTime = 5.0f;
    public float glidertimeLeft;
    public bool isGliding = false;

    public bool isGround = true;

    public int coinCount = 0;
    public int totalCoins = 5;
    public float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        // 글라이더 오브젝트 초기화
        if (gliderObjrct != null)
        {


            gliderObjrct.SetActive(false);

        }
        glidertimeLeft = gliderMaxTime;

        coyoteTimeCounter = 0;      //관성 타이머 초기화
    }

    // Update is called once per frame
    void Update()



    {   //움직임 입력

        UpdateGroundedAtate();



        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


        }
        //지키를 누르는 동안 글라이더 활성화
        if (Input.GetKey(KeyCode.G) && !isGround && glidertimeLeft > 0)
        {
            Debug.Log("클라이더 실행");
            if (!isGround)
            {
                Enableglider();


            }

            glidertimeLeft -= Time.deltaTime;
            if (glidertimeLeft <= 0)
            {

                DisableGlider();

            }
        }
        else if (isGliding)
        {

            DisableGlider();
        }
            if (isGliding)
            {

                ApplyGliderMovement(moveHorizontal, moveVertical);


            }
            else
            {




                //속도값으로 직접 이동
                rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);

                //착지 점프 높이 구현
                if (rb.velocity.y < 0)
                {
                    rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;


                }
                else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                {
                    rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulitipilier - 1) * Time.deltaTime;


                }
            
            if (isGround)
            {

                if (isGliding)
                {

                    DisableGlider();
                }
                glidertimeLeft = gliderMaxTime;
            }

        }


            //점프입력
            if (Input.GetButtonDown("Jump") && isGround)            //&& 두값이 트루일떄 (보통 스페이스바 와 땅위에 있을 떄)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  //위쪽으로 설정한 힘만큼 강체에 힘을 전달한다
                isGround = false;
                realGrounded = false;
                coyoteTimeCounter = 0;                                       //점프를 하는순간 땅에서 떨어졌기 떄문에 폴스 라고 한다.
            }
        


    }


    void OnCollisionEnter(Collision collision)      //충돌이 일어났을떄 호출되는 함수
    {
        if (collision.gameObject.tag == "Ground")            //충돌이 일어난 불(물)체의 태그가 그라운드인경우
        {
            realGrounded = true;                         //땅과 충돌했을떄 트루로 변경해준다

        }
    }
            void OnCollisionStay(Collision collision)      //충돌이 일어났을떄 호출되는 함수
            {
                if (collision.gameObject.tag == "Ground")            //충돌이 일어난 불(물)체의 태그가 그라운드인경우
                {
                    realGrounded = true;                         //땅과 충돌했을떄 트루로 변경해준다

                }

            }
            void OnCollisionExit(Collision collision)      //충돌이 일어났을떄 호출되는 함수
            {
                if (collision.gameObject.tag == "Ground")            //충돌이 일어난 불(물)체의 태그가 그라운드인경우
                {
                    realGrounded = false;                         //땅과 충돌했을떄 트루로 변경해준다

                }

            }

            void OnTriggerEnter(Collider other)
            {
                if (other.CompareTag("Coin"))
                {
                    coinCount++;
                    Destroy(other.gameObject);                                  //코인 오브젝트를 제거한다
                    Debug.Log($"코인 수집:{coinCount}/{totalCoins}");               //수집한 코인 1/5 식으로 콘솔 로그에 표현한다
                }
                if (other.CompareTag("Door") && coinCount >= totalCoins)             // zhdls wjs
                {
                    Debug.Log("게임 클리어");

                }
            }
        
        //지면 상태에서 업데이트 함수
        void UpdateGroundedAtate()
        {
            if (realGrounded)
            {
                coyoteTimeCounter = coyoteTime;
                isGround = true;
            }
            else
            {
                if (coyoteTimeCounter > 0)
                {

                    coyoteTimeCounter -= Time.deltaTime;
                    isGround = true;



                }
                else
                {

                    isGround = false;

                }





            }
        }

        void Enableglider()
        {
            isGliding = true;
            if (gliderObjrct != null)
            {

                gliderObjrct.SetActive(true);
            }
            rb.velocity = new Vector3(rb.velocity.x, -gliderFallSpeed, rb.velocity.z);    //하강속도를 초기화



        }

        void DisableGlider()
        {
            isGliding = false;
            if (gliderObjrct != null)
            {

                gliderObjrct.SetActive(false);
            }
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);    //하강속도를 초기화

        }
        void ApplyGliderMovement(float horizontal, float vertical)
        {
            Vector3 glidervelocity = new Vector3(horizontal * glidermoveSpeed, -gliderFallSpeed, vertical * glidermoveSpeed);

            rb.velocity = glidervelocity;

        }

    
}
    

