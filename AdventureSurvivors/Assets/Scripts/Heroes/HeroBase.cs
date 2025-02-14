using UnityEngine;

public class HeroBase : MonoBehaviour, IDamageable
{
    [SerializeField] private MinMaxValues minMaxStatValues;
    [SerializeField] private HeroData heroData;
    private HeroStats stats;
    public HeroStats Stats { get { return stats; } }

    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private HitReaction hitReaction;   
    [SerializeField] private HeroAnimator heroAnimator;

    private void Awake()
    {
        stats = new HeroStats(heroData.statsData, minMaxStatValues);
        return;
    }

    private void Start()
    {
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnDead += HealthSystem_OnDead;
    }

    private void HealthSystem_OnDead()
    {
        hitReaction.ShowReaction();
    }

    private void HealthSystem_OnDamaged()
    {
        hitReaction.ShowReaction();
    }

    public void TakeDamage(AttackHitInfo attackHitInfo)
    {
        healthSystem.TakeDamage(attackHitInfo.damageAmount);
    }

    public void UpdateFacingDirection(bool facingRight)
    {
        heroAnimator.UpdateXScale(facingRight);
    }

    public void SetWalking(bool value)
    {
        heroAnimator.SetWalking(value);
    }
}
