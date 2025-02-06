using UnityEngine;
using UnityEngine.EventSystems;

public class HeroAnimator : MonoBehaviour
{
    private const string WALKING_BOOL = "Walking";
    private const string DIE_TRIGGER = "DIE";

    [SerializeField] private Animator animator;

    public void SetWalking(bool value)
    {
        animator.SetBool(WALKING_BOOL, value);
    }

    public void Die()
    {
        animator.SetTrigger(DIE_TRIGGER);
    }

    public void UpdateXScale(bool facingRight)
    {
        Vector3 scale = transform.localScale;
        scale.x = facingRight ? 1f : -1f;
        transform.localScale = scale;
    }
}
