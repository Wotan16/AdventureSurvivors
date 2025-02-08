using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour, IDamageable
{
    public static event Action<EnemyBase> OnAnyEnemySpawned;
    public static event Action<EnemyBase> OnAnyEnemyDead;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxVelocity;

    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private HitReaction hitReaction;
    [SerializeField] private Collider2D hitboxCollider;
    private Rigidbody2D rb2D;

    private bool isDead => healthSystem.IsDead;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnDead += HealthSystem_OnDead;

        OnAnyEnemySpawned?.Invoke(this);
    }

    private void FixedUpdate()
    {
        if (isDead)
            return;

        Vector2 directionToPlayer = (PlayerCharacters.Instance.transform.position - transform.position).normalized;
        float currentSpeed = moveSpeed;
        rb2D.AddForce(moveSpeed * directionToPlayer, ForceMode2D.Impulse);

        if(rb2D.linearVelocity.magnitude > maxVelocity)
        {
            Vector2 velocity = rb2D.linearVelocity;
            velocity = velocity.normalized * maxVelocity;
            rb2D.linearVelocity = velocity;
        }
    }

    protected virtual void HealthSystem_OnDead()
    {
        hitReaction.ShowReaction();
        OnAnyEnemyDead?.Invoke(this);
        hitboxCollider.enabled = false;
        Destroy(gameObject, 2f);
    }

    protected virtual void HealthSystem_OnDamaged()
    {
        hitReaction.ShowReaction();
    }

    public void TakeDamage(AttackHitInfo attackHitInfo)
    {
        healthSystem.TakeDamage(attackHitInfo.damageAmount);
    }
}
