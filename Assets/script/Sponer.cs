using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponer : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject misilePrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawninterval = 0.5f;
    public float maxSpawninterval = 2.0f;

    [Header("동전 스폰 확률 설정")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;

    public float timer = 0.0f;
    public float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= nextSpawnTime)
        {
            SpwanObject();
            timer = 0.0f;
            SetNextSpawnTime();

        }


    }
    void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawninterval, maxSpawninterval);


    }
    void SpwanObject()
    {
        Transform spawnTransform = transform;

        int randomValue = Random.Range(0, 100);
        if (randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);

        }
        else
        {
            Instantiate(misilePrefabs, spawnTransform.position, spawnTransform.rotation);

        }

        {



        }


    }
}
