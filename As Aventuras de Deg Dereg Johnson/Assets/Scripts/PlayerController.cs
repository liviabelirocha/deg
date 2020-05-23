using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //unity components
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Collider2D collider;

    //layers
    [SerializeField] private LayerMask ground;

    //inspector variables
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 30f;
    [SerializeField] private int points = 0;
    [SerializeField] private Text pointsText;

    //state machine
    private enum StateMachine { idle, running, jumping, falling };
    private StateMachine state = StateMachine.idle;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        Movement();
        ChangeState();
        animator.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            points += 100;
            pointsText.text = points.ToString();
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        int scale = 1;

        if (hDirection != 0)
        {
            rigidBody.velocity = new Vector2(hDirection * speed, rigidBody.velocity.y);
            if (hDirection < 0) scale = -1;
            transform.localScale = new Vector2(scale, 1);
        }

        if (Input.GetButtonDown("Jump") && collider.IsTouchingLayers(ground)) //jumping
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            state = StateMachine.jumping;
        }
    }

    private void ChangeState()
    {
        if (state == StateMachine.jumping)
        {
            if (rigidBody.velocity.y < .1f) state = StateMachine.falling;
        }
        else if (state == StateMachine.falling)
        {
            if (collider.IsTouchingLayers(ground)) state = StateMachine.idle;
        }
        else if (Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon) state = StateMachine.running;
        else state = StateMachine.idle;

    }
}
