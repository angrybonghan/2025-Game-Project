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
    private void OnTriggerEnter(Collider other)   //�ݶ��̴� �ε��� // ��Ʈ���� �������� ����
    {
        if (other.CompareTag("Missile"))       //���࿡ �±װ� �̻����� �Ϳ� �ε��� �������� 
        {
            currentLives--;                    //����� -1��                             
            Destroy(other.gameObject);
        }    
        
            
                        //�μ�Ʈ���� ������Ʈ


        
        



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
