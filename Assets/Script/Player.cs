using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private float speed = 10f;

    public GameObject bulletPrefab;
    private GameObject[] bullets;
    private int bulletCount = 0;

   

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        bullets = new GameObject[3];
        for (int i = 0; i < 3; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullets[i].SetActive(false);
        }
    }

    void Update()
    {
        // move
        float xInput = Input.GetAxis("Horizontal");
        float xSpeed = xInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed,0f,0f);
        playerRigidbody.velocity = newVelocity;

        /// fire
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (bulletCount < 3)
            {
                bullets[bulletCount].transform.position = gameObject.transform.position;
                bullets[bulletCount].SetActive(true);
                bulletCount++;
            }
        }

        if(bulletCount == 3 && bullets[2].activeSelf == false)
        {
            bulletCount = 0;
        }

      
    }

    public void PlayerDie()
    {
        gameObject.SetActive(false);
    }
}
