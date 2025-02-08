using UnityEngine;

public struct AttackHitInfo
{
    public int damageAmount;
    public Vector3 forceDirection;
    public float force;

    public AttackHitInfo(int damageAmount)
    {
        this = new AttackHitInfo(damageAmount, Vector3.zero, 0f);
    }

    public AttackHitInfo(int damageAmount, Vector3 forceDirection, float force)
    {
        this.damageAmount = damageAmount;
        this.forceDirection = forceDirection;
        this.force = force;
    }
}
