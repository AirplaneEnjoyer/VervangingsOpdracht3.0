using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Projectile Prefabs")]
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private GameObject healthyEnemyProjectile;

    [Header("Raycast & Layers")]
    [SerializeField] private LayerMask enemyLayer; // Set this to your Enemy layer in Inspector

    [Header("Shooting Timers")]
    [SerializeField] private float minShootDelay = 3f; // Minimum seconds between shots
    [SerializeField] private float maxShootDelay = 7f; // Maximum seconds between shots

    private float nextShootTime;

    private void Start()
    {
        SetNextShootTime();
    }

    private void Update()
    {
        if (Time.time >= nextShootTime)
        {
            // ALWAYS reset the timer first so the loop keeps running
            SetNextShootTime();

            // Try to shoot if no enemy is below
            TryShoot();
        }
    }

    private void SetNextShootTime()
    {
        // Pick a new random delay for the next attempt
        nextShootTime = Time.time + Random.Range(minShootDelay, maxShootDelay);
    }

    private void TryShoot()
    {
        // If an enemy is below, skip this attempt, but the timer is already reset for next time
        if (IsEnemyBelow())
            return;

        // 50% chance for regular projectile, 50% chance for healthy projectile
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