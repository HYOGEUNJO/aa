using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 12;
    private Rigidbody bulletRigidbody;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Wall wall = other.GetComponent<Wall>();

            if (wall != null)
            {
                gameObject.SetActive(false);
            }
        }

        if (other.tag == "Player")
        {
            Player Player = other.GetComponent<Player>();

            if (Player != null)
            {
                gameObject.SetActive(false);

                Player.PlayerDie();
            }
        }
    }
}
