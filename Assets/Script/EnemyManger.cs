using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject[] enemies;
    private int enemyCount = 0;

    private float spawnRate = 2;
    private float timeAfterSpawn;

    void Start()
    {

        enemies = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            enemies[i] = Instantiate(enemyPrefab, transform.position, transform.rotation);
            enemies[i].SetActive(false);
        }

        timeAfterSpawn = 0;

    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0;

            if (enemyCount < 5)
            {
                enemies[enemyCount].transform.position = gameObject.transform.position;
                enemies[enemyCount].SetActive(true);

                enemyCount++;
            }

        }

        if (enemyCount == 5 && enemies[4].activeSelf == false)
        {
            enemyCount = 0;
            timeAfterSpawn = 0f;
        }

    }
}
