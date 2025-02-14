using UnityEngine;

public class WizardFireball : HeroSkillBase
{
    [SerializeField] private BaseProjectile prefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float magicDamageMod = 1;


    protected override bool TryPerformSkill()
    {
        if (PlayerCharacters.Instance.closestEnemy == null)
            return false;

        BaseProjectile fireball = Instantiate(prefab, hero.transform.position, Quaternion.identity);

        Vector3 directionToPlayer = GetDirectionToClosestEnemy();
        int damage = (int)(hero.Stats.GetStatOfType(HeroStatType.MagicalDamage).ValueInt * magicDamageMod);
        fireball.SetupProjectile(directionToPlayer, projectileSpeed, damage);
        return true;
    }
}
