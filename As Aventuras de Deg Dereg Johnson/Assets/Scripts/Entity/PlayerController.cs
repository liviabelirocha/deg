using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //unity components
    private Rigidbody2D rigidBody;
    private Animator animator;
    private Collider2D collider;
    private GameController game;

    private bool facingRight = true;

    //layers
    [SerializeField] private LayerMask ground = new LayerMask();

    //inspector variables
    [SerializeField] private float speed = 10f;

    [SerializeField] private Text pointsText = null;
    [SerializeField] private Text healthText = null;

    //sounds
    [SerializeField] private AudioSource jump = null;
    [SerializeField] private AudioSource collectable = null;

    //variables
    private const float jumpForce = 50f;
    private int points = 0;

    //state machine
    private enum StateMachine { idle, running, jumping, falling };
    private StateMachine state = StateMachine.idle;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();

        game = FindObjectOfType<GameController>();
        healthText.text = game.GetHealth().ToString();
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
            }
            else
                game.LoseHealth();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            collectable.Play();
            Destroy(other.gameObject);
            AddPoints(300);
        }
        else if (other.gameObject.tag == "EndLevel")
            game.WinLevel();

    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        CheckFall();

        if (hDirection != 0)
        {
            rigidBody.velocity = new Vector2(hDirection * speed, rigidBody.velocity.y);
            Flip(hDirection < 0 ? false : true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidBody.position, Vector2.down, 1.3f, ground);
            if (hit.collider != null) Jump();
        }
    }

    private void Jump(float force = jumpForce)
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, force);
        state = StateMachine.jumping;
        jump.Play();
    }

    private void AddPoints(int addedPoints)
    {

        points += addedPoints;

        if (points >= 1000)
        {
            game.AddHealth();
            points = 0;
        }

        pointsText.text = points.ToString();
        healthText.text = game.GetHealth().ToString();

    }

    private void CheckFall()
    {
        if (rigidBody.position.y < -10f)
            game.LoseHealth();
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
            RaycastHit2D hit = Physics2D.Raycast(rigidBody.position, Vector2.down, 1.3f, ground);
            if (hit.collider != null) state = StateMachine.idle;
        }
        else if (Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon) state = StateMachine.running;
        else state = StateMachine.idle;
    }

    private void Flip(bool change)
    {
        if (change == facingRight) return;
        facingRight = change;
        transform.Rotate(0f, 180f, 0f);
    }
}
