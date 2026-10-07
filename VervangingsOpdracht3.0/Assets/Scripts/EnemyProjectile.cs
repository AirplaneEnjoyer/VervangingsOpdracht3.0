using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifetime = 4f;

    private void Start()
    {
        // Automatically destroy bullet after lifetime seconds if it misses
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Destroy projectile on impact
            // If your player script handles damage via script components, it will detect this projectile
            Destroy(gameObject);
        }
    }
}