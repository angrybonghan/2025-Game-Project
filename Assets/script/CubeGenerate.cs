using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerate : MonoBehaviour
{
    public GameObject cubePrefab;                           //생ㅅㅓㅇ할 큐브 프리팹
    public int total = 10;                              //총 생성ㅎㅏㄹ 큐브 갯수
    public float cubeSpacing = 1.0f;                    //큐브간ㄱㅕㄱ
    // Start is called before the first frame update
    void Start()
    {
        GenCube();
    }
    public void GenCube()
    {
        Vector3 myPosition = transform.position;                        //스크립ㅌㅡㄱㅏ 붙ㅇㅡㄴ 오브젝ㅌㅡㅇㅢ 위치(XYZ)
        GameObject firestCube = Instantiate(cubePrefab, myPosition, Quaternion.identity);   //첫ㅂㅓㄴ쨰 큐브 생ㅅㅓㅇ 

        for ( int i = 1; i<total; i++)
        {
            //내 위치에서 제트축ㅇㅡㄹㅗ 일ㅈㅓㅇ 간ㄱㅕㄱ 떨ㅇㅓㅈㅣㄴ 위치에 생ㅅㅓㅇ
            Vector3 position = new Vector3(myPosition.x, myPosition.y, myPosition.z + (i * cubeSpacing));
            Instantiate(cubePrefab,position, Quaternion.identity);       //큐브생ㅅㅓㅇ


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
