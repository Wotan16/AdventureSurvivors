using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacters : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<HeroAnimator> heroes;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private bool facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateFacingRight();
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = moveDirection * moveSpeed;

        bool walking = rb.linearVelocity != Vector2.zero;

        foreach (var hero in heroes)
        {
            hero.SetWalking(walking);
        }
    }

    private void UpdateFacingRight()
    {
        if (moveDirection.x == 0)
            return;

        bool newValue = moveDirection.x > 0f;
        if (facingRight != newValue)
        {
            facingRight = newValue;
            //UpdateXScale();
            foreach (var hero in heroes)
            {
                hero.UpdateXScale(facingRight);
            }
        }
    }

    //private void UpdateXScale()
    //{
    //    Vector3 scale = transform.localScale;
    //    scale.x = facingRight ? 1f : -1f;
    //    transform.localScale = scale;
    //}

    #region InputEvents

    public void OnMove_Input(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    #endregion
}