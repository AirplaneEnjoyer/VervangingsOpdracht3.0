using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float horizontalOffset = 1f;
    [SerializeField] private float verticalOffset = -1f;

    [SerializeField] private float verticalStart = 3.5f;
    [SerializeField] private float horizontalStart = -6f;

    [SerializeField] private float verticalMoveAmount = -0.5f;
    [SerializeField] private float horizontalMoveAmount = 0.25f;
    [SerializeField] private float moveDelay = 0.5f;

    [SerializeField] GameObject enemyPrefab;

    private bool hasCollided = false;

    private void Start()
    {
        SpawnEnemies();
        InvokeRepeating("MoveEnemies", 0.5f, 0.5f);
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(enemyPrefab, new Vector3(horizontalStart + (j * horizontalOffset), verticalStart + (i * verticalOffset), 0), Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            SpawnEnemies();

        }
    }


    private void MoveEnemies()
    {
        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Vector3 CurrentPos = enemy.transform.position;
            enemy.transform.position = CurrentPos + new Vector3(horizontalMoveAmount, 0, 0);
            // hier checken voor specifieke posities en dan de richting omdraaien
            float leftBoundary = -60f;
            float rightBoundary = 15f;

            if (CurrentPos.x <= leftBoundary || CurrentPos.x >= rightBoundary)
            {
                horizontalMoveAmount = -horizontalMoveAmount;
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !hasCollided)
        {
            hasCollided = true;
            Invoke("ResetHasCollided", 2f);
            horizontalMoveAmount *= -1;

            foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 currentPos = enemy.transform.position;
                enemy.transform.position = currentPos - new Vector3(0, verticalMoveAmount, 0);
            }
        }
    }

    private void ResetHasCollided()
    {
        hasCollided = false;
    }
}
