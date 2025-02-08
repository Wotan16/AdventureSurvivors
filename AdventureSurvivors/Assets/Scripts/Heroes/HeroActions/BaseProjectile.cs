using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public int damage;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if(collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(new AttackHitInfo(damage));
                Destroy(gameObject);
            }
        }
    }

    public void SetupProjectile(Vector2 direction, float speed, int damage)
    {
        transform.up = direction;
        rb2D.linearVelocity = direction * speed;
        this.damage = damage;
    }
}
