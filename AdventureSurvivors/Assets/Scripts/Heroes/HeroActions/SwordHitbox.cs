using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (collision.TryGetComponent(out IDamageable health))
            {
                health.TakeDamage(new AttackHitInfo(damage));
            }
        }
    }
}
