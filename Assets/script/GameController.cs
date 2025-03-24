using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Timer = 1.0f;         //Ÿ�̸� ������ �����Ѵ�.(float)(���)
    public GameObject EnemyObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        Timer -= Time.deltaTime;            //�ð��� �� �����̸��� ���� ��Ų��(��Ÿ Ÿ���� ������ ������ �ð��� �ǹ�)

        if (Timer <= 0)                     //���� Ÿ�̸��� ��ġ�� 0���Ϸ� ������ ��� (1�ʸ��� ���۵Ǵ� �ൿ�� ���鶧)
        {
            Timer = 1;                          //�ٽ� 1�ʷ� Ÿ�̸Ӹ� �ʱ�ȭ �����ش�


            GameObject Temp = Instantiate(EnemyObject);
            Temp.transform.position = new Vector3(Random.Range(-8, 8),Random.Range(-4, 4), 0);


        }


        {
            if (Input.GetMouseButtonDown(0))                                    //���콺 ��ư�� ��������
            {
                RaycastHit hit;                                                 //���� Hit ����
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //ī�޶󿡼� Ray�� ���� 3D �������� ��ü�� Ȯ�δ�

                if (Physics.Raycast(ray, out hit))                           //Ray�� ������ Hit�Ǵ� ��ü�� ������
                {
                    if (hit.collider != null)                                       //��ü�� �����ϸ�
                    {
                  //Debug.Log($"hit : {hit.collider.name}");         //��ü �̸��� ����Ѵ�
                        hit.collider.gameObject.GetComponent<Enemy>().CharacterHit(30);  //���ʹ� ��ũ��Ʈ�� ��Ʈ�Լ��� ȣ���Ѵ�
                    }
                }
            }
        }
    }
}
