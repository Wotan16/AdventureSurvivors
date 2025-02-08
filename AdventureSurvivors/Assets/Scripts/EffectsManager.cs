using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    private void Awake()
    {
        InitializeSingleton();
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
}
