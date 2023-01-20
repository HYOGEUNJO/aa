using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody enemyRigidbody;
    public float speed = 10f;

    public GameObject bulletPrefab;
    private GameObject[] bullets;
    private int bulletCount = 0;

    private float spawnRate;
    private float spawnRateMin = 0.5f;
    private float spawnRateMax = 3f;
    private float timeAfterSpawn;

    private Transform target;

   

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        enemyRigidbody.velocity = transform.forward * speed;

        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<Player>().transform;

        bullets = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullets[i].SetActive(false);
        }


    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            bullets[bulletCount].transform.position = gameObject.transform.position;
            bullets[bulletCount].SetActive(true);
            bullets[bulletCount].transform.LookAt(target);
            bulletCount++;

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

        if (bulletCount == 3)
        {
            bulletCount = 0;
        }
    }

    public void EnemyDie()
    {
        gameObject.SetActive(false);
    }
}
