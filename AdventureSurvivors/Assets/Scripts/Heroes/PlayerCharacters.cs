using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCharacters : MonoBehaviour
{
    public static PlayerCharacters Instance {  get; private set; }

    [SerializeField] private float moveSpeed;
    public int maxHeroes;
    [SerializeField] private List<HeroBase> heroes;
    [SerializeField] private List<Transform> heroPlaces;
    [SerializeField] private EnemiesAround enemiesAround;
    [SerializeField] private PlayerInteraction interaction;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public bool ControlledByPlayer = true;

    public EnemyBase closestEnemy => enemiesAround.closestEnemy;
    public bool facingRight { get; private set; }
    public bool partyFull { get { return heroes.Count == maxHeroes; } }

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

    public void AddHero(HeroData heroData)
    {
        if (partyFull)
            return;

        int placeIndex = heroes.Count;
        Transform heroPlace = heroPlaces[placeIndex];
        HeroBase hero = Instantiate(heroData.prefab, heroPlace.position, Quaternion.identity, transform);
        heroes.Add(hero);
    }

    #region InputEvents

    public void OnMove_Input(InputAction.CallbackContext context)
    {
        if (!ControlledByPlayer)
        {
            moveDirection = Vector2.zero;
            return;
        }

        moveDirection = context.ReadValue<Vector2>();
    }

    public void OnInteract_Input(InputAction.CallbackContext context)
    {
        if (!ControlledByPlayer)
            return;

        if (!interaction.hasInteractableAround)
            return;

        if (!context.started)
            return;

        interaction.targetInteractable.OnInteract();
    }

    #endregion
}