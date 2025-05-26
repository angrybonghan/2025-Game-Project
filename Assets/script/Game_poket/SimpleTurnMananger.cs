using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurnMananger : MonoBehaviour
{
    public static bool canplay = true;
    public static bool anyBallMoving = false;       //언떤

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAllBalls();
        if (!anyBallMoving && !canplay)
        {

            canplay = true;
            Debug.Log("턴종료 다시공을 칠수잇습니다");
        }
    }
    void CheckAllBalls()
    {
        SimpleBallController[] allBalls = FindObjectsOfType<SimpleBallController>();
        anyBallMoving = false;

        foreach(SimpleBallController ball in allBalls)
        {
            if(ball .IsMoving())
            {
                anyBallMoving = true;
                break;
            }

        }
    }
    public static void OnBallHit()
    {
        canplay = false;
        anyBallMoving = true;
        Debug.Log("턴 시작! 공이 멈출때까지 기다리세요");

    }


}
