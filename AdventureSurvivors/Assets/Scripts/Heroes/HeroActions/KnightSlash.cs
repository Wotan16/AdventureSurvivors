using UnityEngine;

public class KnightSlash : HeroSkillBase
{
    [SerializeField] private SwordHitbox swordHitbox;
    [SerializeField] private Animator animator;
    [SerializeField] private float damageModifier = 1f;

    protected override bool TryPerformSkill()
    {
        EnemyBase closestEnemy = PlayerCharacters.Instance.closestEnemy;
        if(closestEnemy == null)
            return false;

        swordHitbox.damage = (int)(hero.Stats.GetStatOfType(HeroStatType.PhysicalDamage).Value * damageModifier);

        Vector3 closestEnemyPosition = closestEnemy.transform.position;
        Vector2 directionToEnemy = closestEnemyPosition - transform.position;
        swordHitbox.transform.up = directionToEnemy.normalized;
        animator.SetTrigger("PlayEffect");
        return true;
    }
}
