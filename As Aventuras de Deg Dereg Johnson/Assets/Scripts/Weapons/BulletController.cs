using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D body = null;

    void Start()
    {
        body.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.Hit();
            Destroy(gameObject);
        }
    }
}

