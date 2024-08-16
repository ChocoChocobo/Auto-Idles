using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : StaticInstance<GridManager>
{
    [Header("Grid params")]
    [SerializeField] private int gridWidth, gridHeight;
    [SerializeField] private int playerGridStartPos, enemyGridStartPos;
    [Header("Attachables")]
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private EnemyTile enemyTilePrefab;
    [SerializeField] private Transform cam;
    [SerializeField] private Transform gridPlayerParent;
    [SerializeField] private Transform gridEnemyParent;

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
                var spawnedTile = Instantiate(tilePrefab, new Vector3(playerGridStartPos + x, y), Quaternion.identity, gridPlayerParent);
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
                var spawnedTile = Instantiate(enemyTilePrefab, new Vector3(enemyGridStartPos + x, y), Quaternion.identity, gridEnemyParent);
                spawnedTile.name = $"Enemy tile {x}-{y}";
            }
        }
    }
}
