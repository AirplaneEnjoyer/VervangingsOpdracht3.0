using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private SpriteRenderer sr;

    private Vector2 movement;

    // Update is called once per frame
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + movement * _speed * Time.fixedDeltaTime);
    }
}
