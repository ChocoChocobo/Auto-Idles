using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int gridWidth, gridHeight;
    [SerializeField] private int playerGridStartPos, enemyGridStartPos;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private EnemyTile enemyTilePrefab;
    [SerializeField] private Transform cam;

    private void Start()
    {
        GenerateGridPlayer();
        GenerateGridEnemy();
    }

    private void GenerateGridPlayer()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(playerGridStartPos + x, y), Quaternion.identity, transform);
                spawnedTile.name = $"Tile {x}-{y}";
            }
        }
        cam.transform.position = new Vector3((float)gridWidth / 2 - 0.5f, (float)gridHeight / 2 - 0.5f, -10);
    }

    private void GenerateGridEnemy()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var spawnedTile = Instantiate(enemyTilePrefab, new Vector3(enemyGridStartPos + x, y), Quaternion.identity, transform);
                spawnedTile.name = $"Enemy tile {x}-{y}";
            }
        }
    }
}
