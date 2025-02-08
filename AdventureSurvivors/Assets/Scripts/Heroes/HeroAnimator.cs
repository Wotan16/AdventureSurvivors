using UnityEngine;
using UnityEngine.EventSystems;

public class HeroAnimator : MonoBehaviour
{
    private const string WALKING_BOOL = "Walking";
    private const string DIE_TRIGGER = "DIE";

    [SerializeField] private SpriteRenderer spriteRenderer;
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
        spriteRenderer.flipX = !facingRight;
    }
}
