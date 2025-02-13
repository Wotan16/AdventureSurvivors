using System;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [SerializeField] private Chunk chunkPrefab;
    [SerializeField] private float cellSize;
    public Vector2Int activeGridPosition;
    private List<Chunk> loadedChunks = new List<Chunk>();

    private void Start()
    {
        UpdateGrid();
    }

    private void Update()
    {
        Vector2 playerPos = PlayerCharacters.Instance.transform.position;
        Vector2Int activeChunkPos = GetGridPositionValue(playerPos);
        if(activeGridPosition != activeChunkPos)
        {
            activeGridPosition = activeChunkPos;
            UpdateGrid();
        }
    }

    private Vector2Int GetGridPositionValue(Vector2 worldPos)
    {
        int xPos = (int)(worldPos.x / cellSize);
        int yPos = (int)(worldPos.y / cellSize);

        if (worldPos.x < 0)
            xPos--;
        if (worldPos.y < 0)
            yPos--;

        return new Vector2Int(xPos, yPos);
    }

    private Vector2 GetWorldPosition(Vector2Int gridPosition)
    {
        return new Vector2(gridPosition.x, gridPosition.y) * cellSize;
    }

    private void UpdateGrid()
    {
        RemoveDistantChunks();
        GenerateNewChunks();
    }

    private void GenerateNewChunks()
    {
        List<Vector2Int> existingChunkPositions = new List<Vector2Int>();
        foreach(Chunk chunk in loadedChunks)
        {
            existingChunkPositions.Add(chunk.gridPosition);
        }

        for(int i = 0; i <= 2; i++)
        {
            for(int j = 0; j <= 2; j++)
            {
                Vector2Int gridDirection = new Vector2Int(i - 1, j - 1);
                Vector2Int gridPosition = activeGridPosition + gridDirection;
                if (existingChunkPositions.Contains(gridPosition))
                    continue;
                Vector2 worldPosition = GetWorldPosition(gridPosition);
                Chunk chunk = Instantiate(chunkPrefab, worldPosition, Quaternion.identity, transform);
                chunk.gridPosition = gridPosition;
                loadedChunks.Add(chunk);
            }
        }
    }

    private void RemoveDistantChunks()
    {
        List<Chunk> validChunks = new List<Chunk>();
        foreach (Chunk chunk in loadedChunks)
        {
            Vector2Int chunkGridPos = chunk.gridPosition;
            if (Mathf.Abs(chunkGridPos.x - activeGridPosition.x) > 1 || Mathf.Abs(chunkGridPos.y - activeGridPosition.y) > 1)
            {
                Destroy(chunk.gameObject);
                continue;
            }
            validChunks.Add(chunk);
        }
        loadedChunks = validChunks;
    }
}
