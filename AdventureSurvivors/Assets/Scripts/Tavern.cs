using UnityEngine;

public class Tavern : MonoBehaviour, IInteractable
{
    [SerializeField] private int numberOfUses;

    public bool CanInteract()
    {
        return numberOfUses > 0;
    }

    public void OnInteract()
    {
        numberOfUses--;
        Debug.Log("Opened Tavern");
    }
}
