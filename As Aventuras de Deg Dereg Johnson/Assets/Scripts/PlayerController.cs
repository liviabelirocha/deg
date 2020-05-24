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
    [SerializeField] private int points = 0;
    [SerializeField] private int health = 9;
    [SerializeField] private Text pointsText;
    [SerializeField] private Text healthText;

    //variables
    private const float jumpForce = 50f;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (state == StateMachine.falling)
            {
                EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
                enemy.Trigger();
                Jump(40f);
                addPoints(200);
            }
            else
            {
                health -= 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
            addPoints(100);
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

        if (Input.GetButtonDown("Jump") && collider.IsTouchingLayers(ground)) Jump();
    }

    private void Jump(float force = jumpForce)
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, force);
        state = StateMachine.jumping;
    }

    private void addPoints(int addedPoints)
    {
        points += addedPoints;
        pointsText.text = points.ToString();
    }

    private void ChangeState()
    {
        if (state == StateMachine.jumping ||
           ((state == StateMachine.running) && !collider.IsTouchingLayers(ground)))
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
