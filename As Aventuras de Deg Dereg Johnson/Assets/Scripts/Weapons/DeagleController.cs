using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeagleController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private Transform player = null;
    [SerializeField] private Transform FirePoint = null;
    [SerializeField] private GameObject bulletPrefab = null;

    void Start()
    {
        transform.position = new Vector3(player.position.x + 1, player.position.y - 0.2f, transform.position.z);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();

    }

    private void Shoot()
    {
        animator.SetTrigger("Fire");
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
