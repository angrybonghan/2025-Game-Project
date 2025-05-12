using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour      //�� �����Ȥ��Ӥ� �������������Ѥ��� �ΰ����Ϥ����Ѥ��Ѥ��Ӥ�
{
    //(���̤� Ÿ�̤� ����������������������
    public int fruitType;


    public bool hasMerged = false;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged)
            return;


        Fruit otheFruit = collision.gameObject.GetComponent<Fruit>();

       if(  otheFruit != null && !otheFruit.hasMerged && otheFruit.fruitType == fruitType)
        {

            hasMerged = true;
            otheFruit.hasMerged = true;

            Vector3 mergePosition = (transform.position = otheFruit.transform.position) / 2f;

            FruitGame gameMamager = FindObjectOfType<FruitGame>();

            if(gameMamager != null)
            {

                gameMamager.MergeFruits(fruitType, mergePosition);

            }


            Destroy(otheFruit.gameObject);
            Destroy(gameObject);

        }
    }

}
