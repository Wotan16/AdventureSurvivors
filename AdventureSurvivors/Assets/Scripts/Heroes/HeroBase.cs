using UnityEngine;

public class HeroBase : MonoBehaviour, IDamageable
{
    [SerializeField] private int basePhysicalDamage;
    [SerializeField] private int baseMagicalDamage;
    [SerializeField] private float baseAttackSpeed = 1;
    public HeroStat physicalDamage { get; private set; }
    public HeroStat magicalDamage { get; private set; }
    public HeroStat attackSpeed { get; private set; }

    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private HitReaction hitReaction;
    [SerializeField] private HeroAnimator heroAnimator;

    private void Awake()
    {
        physicalDamage = new HeroStat(basePhysicalDamage, 0, 10000);
        magicalDamage = new HeroStat(baseMagicalDamage, 0, 10000);
        attackSpeed = new HeroStat(baseAttackSpeed, 0.1, 10);
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
