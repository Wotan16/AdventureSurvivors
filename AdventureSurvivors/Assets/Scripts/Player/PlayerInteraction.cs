using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction Instance { get; private set; }

    [SerializeField] private float interactionRange;
    private LayerMask interactableMask;
    public IInteractable targetInteractable {  get; private set; }
    public bool hasInteractableAround;

    private void Awake()
    {
        InitializeSingleton();

        interactableMask = (1 << MyLayerManager.interactableLayer);
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

    void Update()
    {
        CheckForInteractable();
        hasInteractableAround = targetInteractable != null;
    }

    private void CheckForInteractable()
    {
        Collider2D interactableColl = Physics2D.OverlapCircle(transform.position, interactionRange, interactableMask);
        if (interactableColl != null)
        {
            if (interactableColl.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.CanInteract())
                {
                    targetInteractable = interactable;
                    return;
                }
            }
        }

        targetInteractable = null;
    }

    private void OnDrawGizmos()
    {
        Color color = targetInteractable == null ? Color.red : Color.green;
        Gizmos.color = color;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
