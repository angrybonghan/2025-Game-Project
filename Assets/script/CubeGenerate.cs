using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerate : MonoBehaviour
{
    public GameObject cubePrefab;                           //�����ä��� ť�� ������
    public int total = 10;                              //�� ���������� ť�� ����
    public float cubeSpacing = 1.0f;                    //ť�갣���Ť�
    // Start is called before the first frame update
    void Start()
    {
        GenCube();
    }
    public void GenCube()
    {
        Vector3 myPosition = transform.position;                        //��ũ�����Ѥ��� �٤��Ѥ� ���������Ѥ��� ��ġ(XYZ)
        GameObject firestCube = Instantiate(cubePrefab, myPosition, Quaternion.identity);   //ù���ä��� ť�� �����ä� 

        for ( int i = 1; i<total; i++)
        {
            //�� ��ġ���� ��Ʈ�ष�Ѥ��� �Ϥ��ä� �����Ť� �����ä��Ӥ� ��ġ�� �����ä�
            Vector3 position = new Vector3(myPosition.x, myPosition.y, myPosition.z + (i * cubeSpacing));
            Instantiate(cubePrefab,position, Quaternion.identity);       //ť������ä�


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
