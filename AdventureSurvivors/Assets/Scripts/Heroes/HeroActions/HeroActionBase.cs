using UnityEngine;

public abstract class HeroActionBase : MonoBehaviour
{
    [SerializeField] protected float cooldown = 1f;
    protected float cdDelta = 1f;
    [SerializeField] protected HeroBase hero;

    public void SetHero(HeroBase hero)
    {
        this.hero = hero;
    }

    protected virtual void Update()
    {
        if(cdDelta <= 0f)
        {
            if (TryPerformAction())
            {
                float cdMod = 1 / (float)hero.attackSpeed.Value;
                cdDelta = cooldown * cdMod;
            }
            return;
        }

        cdDelta -= Time.deltaTime;
    }

    protected abstract bool TryPerformAction();

    protected Vector2 GetDirectionToClosestEnemy()
    {
        EnemyBase closestEnemy = PlayerCharacters.Instance.closestEnemy;
        Vector3 closestEnemyPosition = closestEnemy.transform.position;
        Vector2 directionToEnemy = closestEnemyPosition - transform.position;
        return directionToEnemy.normalized;
    }
}
