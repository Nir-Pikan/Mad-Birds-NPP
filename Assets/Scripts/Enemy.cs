using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _CloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_CloudParticlePrefab,transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
            Destroy(gameObject);
            return;
        }

        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
            return;

        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_CloudParticlePrefab, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("MonsterDeath");
            Destroy(gameObject);
        }
    }
}
