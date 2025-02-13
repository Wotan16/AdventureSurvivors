using UnityEngine;

public interface IInteractable
{
    bool CanInteract();
    void OnInteract();
    //string GetHintText();
    //Vector2 GetHintPosition();
}
