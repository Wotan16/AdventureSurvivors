using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacters : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
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
    }

    private void UpdateFacingRight()
    {
        if (moveDirection.x == 0)
            return;

        bool newValue = moveDirection.x > 0f;
        if (facingRight != newValue)
        {
            facingRight = newValue;
            UpdateXScale();
        }
    }

    private void UpdateXScale()
    {
        if (moveDirection.x == transform.localScale.x || moveDirection.x == 0f)
            return;

        Vector3 scale = transform.localScale;
        scale.x = facingRight ? 1f : -1f;
        transform.localScale = scale;
    }

    #region InputEvents

    public void OnMove_Input(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    #endregion
}