using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;          //큐브 이도ㅇㅅㅗㄱ도 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -moveSpeed * Time.deltaTime);         //제트축 마이너스 방ㅎㅑㅇ으로 이도ㅇ

        if(transform.position.z < -20)
        {
            Destroy(gameObject);


        }
    }
}
