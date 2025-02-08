using UnityEngine;

public class KnightSlash : HeroActionBase
{
    [SerializeField] private SwordHitbox swordHitbox;
    [SerializeField] private Animator animator;
    [SerializeField] private float damageModifier = 1f;

    protected override bool TryPerformAction()
    {
        EnemyBase closestEnemy = PlayerCharacters.Instance.closestEnemy;
        if(closestEnemy == null)
            return false;

        swordHitbox.damage = (int)(hero.physicalDamage.Value * damageModifier);

        Vector3 closestEnemyPosition = closestEnemy.transform.position;
        Vector2 directionToEnemy = closestEnemyPosition - transform.position;
        swordHitbox.transform.up = directionToEnemy.normalized;
        animator.SetTrigger("PlayEffect");
        return true;
    }
}
