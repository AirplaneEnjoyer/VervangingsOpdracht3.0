using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] GameObject PlayerBulletPrefab;

    private static int enemiesDestroyed = 0;

    private void Start()
    {
        Invoke("AddCollider", 0.2f);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerMovement playerController = player.GetComponent<PlayerMovement>();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            enemiesDestroyed++;

            if (enemiesDestroyed >= 100)
            {
                SceneManager.LoadScene("WinMenu");
                enemiesDestroyed = 0;
            }
        }
    }

    private void AddCollider()
    {
        this.AddComponent<CapsuleCollider2D>();
    }
}
