using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacters : MonoBehaviour
{
    public static PlayerCharacters Instance {  get; private set; }

    [SerializeField] private float moveSpeed;
    [SerializeField] private List<HeroBase> heroes;
    [SerializeField] private EnemiesAround enemiesAround;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public EnemyBase closestEnemy => enemiesAround.closestEnemy;
    public bool facingRight { get; private set; }

    private void Awake()
    {
        InitializeSingleton();

        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    private void InitializeSingleton()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one " + GetType().Name);
            Destroy(gameObject);
            return;
        }
        Instance = this;
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
            foreach (var hero in heroes)
            {
                hero.UpdateFacingDirection(facingRight);
            }
        }
    }

    #region InputEvents

    public void OnMove_Input(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    #endregion
}