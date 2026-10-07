using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Projectile Prefabs")]
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private GameObject healthyEnemyProjectile;

    [Header("Raycast & Layers")]
    [SerializeField] private LayerMask enemyLayer;

    [Header("Shooting Timers")]
    [SerializeField] private float minShootDelay = 3f;
    [SerializeField] private float maxShootDelay = 7f;

    private float nextShootTime;

    private void Start()
    {
        SetNextShootTime();
    }

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            SetNextShootTime();

            TryShoot();
        }
    }

    private void SetNextShootTime()
    {
        nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
    }

    private void TryShoot()
    {
        if (IsEnemyBelow())
            return;

        float rand = Random.value;

        if (rand < 0.5f)
        {
            Shoot(enemyProjectile);
        }
        else
        {
            Shoot(healthyEnemyProjectile);
        }
    }

    private bool IsEnemyBelow()
    {
        Vector3 origin = transform.position - new Vector3(0, 0.6f, 0);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, 1.0f, enemyLayer);
        return hit.collider != null;
    }

    private void Shoot(GameObject projectilePrefab)
    {
        if (projectilePrefab != null)
        {
            Vector3 spawnPos = transform.position - new Vector3(0, 0.6f, 0);
            Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        }
    }
}