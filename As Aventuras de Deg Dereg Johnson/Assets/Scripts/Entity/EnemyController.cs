﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //unity components
    private Rigidbody2D rigidBody;
    private Animator animator;

    //inspector variables
    [SerializeField] private float speed = -5f;

    //sounds
    [SerializeField] private AudioSource explosion = null;

    private bool hit = false;

    //state machine
    private enum StateMachine { walking, dying };
    private StateMachine state = StateMachine.walking;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Waypoint")
        {
            transform.localScale = new Vector2(-transform.localScale.x, 1);
            speed = -speed;
        }
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
        animator.SetInteger("state", (int)state);
    }

    public void Trigger()
    {
        state = StateMachine.dying;
        speed = 0;
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Collider2D>().enabled = false;
        explosion.Play();

    }

    public void Hit()
    {
        if (hit) Trigger();
        else hit = true;
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }
}
