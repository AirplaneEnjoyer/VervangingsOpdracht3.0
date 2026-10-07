using UnityEngine;

public class HealthyEnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minXScale = 0.1f;
    [SerializeField] private float shrinkFactor = 0.9f;
    [SerializeField] private float lifetime = 4f;

    private void Start()
    {
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
            Transform playerTransform = collision.transform;
            Vector3 currentScale = playerTransform.localScale;

            float newXScale = Mathf.Max(currentScale.x * shrinkFactor, minXScale);
            playerTransform.localScale = new Vector3(newXScale, currentScale.y, currentScale.z);

            Debug.Log("Player slimmed down! New scale: " + playerTransform.localScale);

            Destroy(gameObject);
        }
    }
}