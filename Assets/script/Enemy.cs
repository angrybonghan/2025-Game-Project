using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;           //ü���� ���� �Ѵ�. (int)(����)
    public float Timer = 1.0f;         //Ÿ�̸� ������ �����Ѵ�.(float)(���)
    public int AttackPoint = 50;       //���ݷ¸� �� �� �� ��.

    //���� �������� ������Ʈ �Ǳ� �� �ѹ� ���� �ȴ�.
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;                        //�� ��ũ��Ʈ�� ���� �� �� 100���� ����




    }
    //���� �������� �� ������ ���� ȣ��ȴ�
    // Update is called once per frame
    void Update()
    {

        CharacterHealthUp();

        if (Input.GetKeyDown(KeyCode.Space))             //�����̽�Ű�� ��������
          {
            Health -= AttackPoint;                      //ü�� ����Ʈ�� ���� ����Ʈ��ŭ ���ҽ����ش�
                                                                //Hp=Hp-At
        }
        CheckDeath();


    }
    void CharacterHealthUp()
    {


        Timer -= Time.deltaTime;            //�ð��� �� �����̸��� ���� ��Ų��(��Ÿ Ÿ���� ������ ������ �ð��� �ǹ�)

        if (Timer <= 0)                     //���� Ÿ�̸��� ��ġ�� 0���Ϸ� ������ ��� (1�ʸ��� ���۵Ǵ� �ൿ�� ���鶧)
        {
            Timer = 1;                          //�ٽ� 1�ʷ� Ÿ�̸Ӹ� �ʱ�ȭ �����ش�
            Health += 10;                       //1�ʸ��� ü���� 10�� �÷��ش�
        }




    }



public  void CharacterHit(int Damage)               //�������� �޴� �Լ��� �����Ѵ�
    {
        Health -= Damage;                       //���� ���ݷ¿� ���� ü���� ���ҽ�Ų��

    }
    void CheckDeath()
    {

        if (Health <= 0)                      //ü���� 0���� �� ���
        {
            Destroy(gameObject);        //�� ������Ʈ�� �ı���Ų��
        }



    }


}
