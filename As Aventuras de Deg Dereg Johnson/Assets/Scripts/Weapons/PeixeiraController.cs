using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeiraController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private AudioSource attack = null;

    [SerializeField] private Transform AttackPoint = null;
    [SerializeField] private float AttackRange = 5f;
    [SerializeField] private LayerMask EnemyLayer = new LayerMask();

    void Start()
    {
        transform.position = new Vector3(player.position.x + 1, player.position.y - 0.2f, transform.position.z);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2")) Attack();
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        attack.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayer);
        foreach (Collider2D enemy in hitEnemies)
            enemy.GetComponent<EnemyController>().Trigger();

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
}
