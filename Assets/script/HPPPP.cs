using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPPPP : MonoBehaviour
{
    public int maxLives = 3;
    public int currentLives = 1;

    public float invincibleTime = 1.0f;
    public bool isinvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;
    }
    private void OnTriggerEnter(Collider other)   //콜라이더 부딪힘 // 온트리거 지나가게 해줌
    {
        if (other.CompareTag("Missile"))       //만약에 태그가 미사일인 것에 부딪혀 지나가면 
        {
            currentLives--;                    //목숨이 -1됨                             
            Destroy(other.gameObject);
        }    
        
            
                        //부서트린다 오브젝트


        
        



    }

    public void GameOver()
    {

        gameObject.SetActive(false);
        Invoke("RestartGame", 3.0f);

    }
    public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
