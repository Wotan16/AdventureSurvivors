using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2Int gridPosition;
    public Vector2 worldPosition => transform.position;
}
