using UnityEngine;

public class WizardFireball : HeroActionBase
{
    [SerializeField] private BaseProjectile prefab;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float magicDamageMod = 1;


    protected override bool TryPerformAction()
    {
        if (PlayerCharacters.Instance.closestEnemy == null)
            return false;

        BaseProjectile fireball = Instantiate(prefab, hero.transform.position, Quaternion.identity);

        Vector3 directionToPlayer = GetDirectionToClosestEnemy();
        int damage = (int)(hero.magicalDamage.ValueInt * magicDamageMod);
        fireball.SetupProjectile(directionToPlayer, projectileSpeed, damage);
        return true;
    }
}
