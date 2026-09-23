using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject playerProjectile;
    [SerializeField] private float shootCooldown = 0.5f;

    private Vector2 movement;
    private float lastShootTime = 0f;

    // Update is called once per frame
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * _speed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        if (Time.time > lastShootTime + shootCooldown)
        {
            Instantiate(playerProjectile, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            lastShootTime = Time.time;
        }
    }

}
