using UnityEngine;

public class Weapon2Bullet : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 4.5f;

    private void Update()
    {
        transform.position += speed * Time.deltaTime * transform.up;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyHealth>();

        if (enemy)
        {
            enemy.Hit(60);
        }

        Destroy(gameObject);
    }
}