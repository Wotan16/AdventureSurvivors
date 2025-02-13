using UnityEngine;

public class InteractionHintUI : MonoBehaviour
{
    [SerializeField] private GameObject hintObject;

    private void Update()
    {
        hintObject.SetActive(PlayerInteraction.Instance.hasInteractableAround);
    }
}
