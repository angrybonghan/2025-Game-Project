using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlpyerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                  //�̵����Ǥ��� 
    public Rigidbody rb;
    public float jumpForce = 7.0f;
    [Header("���� ���� ����")]
    public float fallMultiplier = 2.5f;     //�ϰ� �߷� ����
    public float lowJumpMulitipilier = 2.0f;        //ª�� ���� ����
    [Header("���� ���� ����")]
    public float coyoteTime = 0.15f;
    public float coyoteTimeCounter;
    public bool realGrounded = true;
    [Header("�۶��̴� ����")]
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
        // �۶��̴� ������Ʈ �ʱ�ȭ
        if (gliderObjrct != null)
        {


            gliderObjrct.SetActive(false);

        }
        glidertimeLeft = gliderMaxTime;

        coyoteTimeCounter = 0;      //���� Ÿ�̸� �ʱ�ȭ
    }

    // Update is called once per frame
    void Update()



    {   //������ �Է�

        UpdateGroundedAtate();



        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        if (movement.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);


        }
        //��Ű�� ������ ���� �۶��̴� Ȱ��ȭ
        if (Input.GetKey(KeyCode.G) && !isGround && glidertimeLeft > 0)
        {
            Debug.Log("Ŭ���̴� ����");
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




                //�ӵ������� ���� �̵�
                rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);

                //���� ���� ���� ����
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


            //�����Է�
            if (Input.GetButtonDown("Jump") && isGround)            //&& �ΰ��� Ʈ���ϋ� (���� �����̽��� �� ������ ���� ��)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  //�������� ������ ����ŭ ��ü�� ���� �����Ѵ�
                isGround = false;
                realGrounded = false;
                coyoteTimeCounter = 0;                                       //������ �ϴ¼��� ������ �������� ������ ���� ��� �Ѵ�.
            }
        


    }


    void OnCollisionEnter(Collision collision)      //�浹�� �Ͼ���� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.tag == "Ground")            //�浹�� �Ͼ ��(��)ü�� �±װ� �׶����ΰ��
        {
            realGrounded = true;                         //���� �浹������ Ʈ��� �������ش�

        }
    }
            void OnCollisionStay(Collision collision)      //�浹�� �Ͼ���� ȣ��Ǵ� �Լ�
            {
                if (collision.gameObject.tag == "Ground")            //�浹�� �Ͼ ��(��)ü�� �±װ� �׶����ΰ��
                {
                    realGrounded = true;                         //���� �浹������ Ʈ��� �������ش�

                }

            }
            void OnCollisionExit(Collision collision)      //�浹�� �Ͼ���� ȣ��Ǵ� �Լ�
            {
                if (collision.gameObject.tag == "Ground")            //�浹�� �Ͼ ��(��)ü�� �±װ� �׶����ΰ��
                {
                    realGrounded = false;                         //���� �浹������ Ʈ��� �������ش�

                }

            }

            void OnTriggerEnter(Collider other)
            {
                if (other.CompareTag("Coin"))
                {
                    coinCount++;
                    Destroy(other.gameObject);                                  //���� ������Ʈ�� �����Ѵ�
                    Debug.Log($"���� ����:{coinCount}/{totalCoins}");               //������ ���� 1/5 ������ �ܼ� �α׿� ǥ���Ѵ�
                }
                if (other.CompareTag("Door") && coinCount >= totalCoins)             // zhdls wjs
                {
                    Debug.Log("���� Ŭ����");

                }
            }
        
        //���� ���¿��� ������Ʈ �Լ�
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
            rb.velocity = new Vector3(rb.velocity.x, -gliderFallSpeed, rb.velocity.z);    //�ϰ��ӵ��� �ʱ�ȭ



        }

        void DisableGlider()
        {
            isGliding = false;
            if (gliderObjrct != null)
            {

                gliderObjrct.SetActive(false);
            }
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);    //�ϰ��ӵ��� �ʱ�ȭ

        }
        void ApplyGliderMovement(float horizontal, float vertical)
        {
            Vector3 glidervelocity = new Vector3(horizontal * glidermoveSpeed, -gliderFallSpeed, vertical * glidermoveSpeed);

            rb.velocity = glidervelocity;

        }

    
}
    

