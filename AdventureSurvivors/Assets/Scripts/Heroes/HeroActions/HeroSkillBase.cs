using UnityEngine;

public abstract class HeroSkillBase : MonoBehaviour
{
    public SkillData skillData;
    [SerializeField] protected float cooldown = 1f;
    protected float cdDelta = 1f;
    [SerializeField] protected HeroBase hero;

    public void SetSkillParams(HeroBase hero, SkillData skillData)
    {
        this.skillData = skillData;
        this.hero = hero;
    }

    protected virtual void Update()
    {
        if(cdDelta <= 0f)
        {
            if (TryPerformSkill())
            {
                float cdMod = 1 / (float)hero.Stats.GetStatOfType(HeroStatType.AttackSpeed).Value;
                cdDelta = cooldown * cdMod;
            }
            return;
        }

        cdDelta -= Time.deltaTime;
    }

    protected abstract bool TryPerformSkill();

    protected Vector2 GetDirectionToClosestEnemy()
    {
        EnemyBase closestEnemy = PlayerCharacters.Instance.closestEnemy;
        Vector3 closestEnemyPosition = closestEnemy.transform.position;
        Vector2 directionToEnemy = closestEnemyPosition - transform.position;
        return directionToEnemy.normalized;
    }
}
