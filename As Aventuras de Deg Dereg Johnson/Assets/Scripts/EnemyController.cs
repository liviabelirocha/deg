using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    [SerializeField] private float speed = -5f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            transform.localScale = new Vector2(-transform.localScale.x, 1);
            speed = -speed;
        }
    }

    private void Update()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
    }
}
