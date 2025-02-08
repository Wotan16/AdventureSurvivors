using UnityEngine;

public class HitReaction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float time = 0.1f;
    private float timeDelta;

    private void Update()
    {
        if (timeDelta <= 0f)
        {
            spriteRenderer.color = Color.white;
            return;
        }

        float halfTime = time / 2;
        timeDelta -= Time.deltaTime;

        Color newColor = Color.red;

        if (timeDelta < halfTime)
        {
            float value = 1 - timeDelta / halfTime;
            newColor = new Color(1, value, value);
        }
        else
        {
            float t = timeDelta - halfTime;
            float value = t / halfTime;
            newColor = new Color(1, value, value);

        }
        spriteRenderer.color = newColor;
    }

    public void ShowReaction()
    {
        timeDelta = time;
    }
}
