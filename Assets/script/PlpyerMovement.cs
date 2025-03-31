using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlpyerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;                  //�̵����Ǥ��� 
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
    {   //������ �Է�
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //�ӵ������� ���� �̵�
        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVertical * moveSpeed);



        if (Input.GetButtonDown("Jump") && isGround)            //&& �ΰ��� Ʈ���ϋ� (���� �����̽��� �� ������ ���� ��)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);  //�������� ������ ����ŭ ��ü�� ���� �����Ѵ�
            isGround = false;                       //������ �ϴ¼��� ������ �������� ������ ���� ��� �Ѵ�.
        }



    }


    void OnCollisionEnter(Collision collision)      //�浹�� �Ͼ���� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.tag == "Ground")            //�浹�� �Ͼ ��(��)ü�� �±װ� �׶����ΰ��
        {
            isGround = true;                         //���� �浹������ Ʈ��� �������ش�

        }


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")) ;
        {
            coinCount++;
            Destroy(other.gameObject);                                  //���� ������Ʈ�� �����Ѵ�
            Debug.Log($"���� ����:{coinCount}/{totalCoins}");               //������ ���� 1/5 ������ �ܼ� �α׿� ǥ���Ѵ�
        }
        if(other.CompareTag("Door") && coinCount >= totalCoins)             // zhdls wjs
        {
            Debug.Log("���� Ŭ����");

        }
    }
}
