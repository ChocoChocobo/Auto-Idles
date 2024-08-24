using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// BattleInitializer is a class that is responsible for pre battle initialization. I.e. placing enemies and lodaing your active idol roster
/// </summary>
public class BattleInitializer : StaticInstance<BattleInitializer>
{
    [SerializeField] private Transform[] spawnPoints;

    public bool battleStarted = false;

    [SerializeField] private GameObject gridPlayerParent;
    [SerializeField] private GameObject gridEnemyParent;

    [SerializeField] private int idolsAmount;

    private void Start()
    {
        SpawnPlayerIdols();
        SpawnEnemyIdols();
    }

    private void SpawnPlayerIdols()
    {
        Tile[] playerTiles = new Tile[gridPlayerParent.transform.childCount];
        for (int i = 0; i < playerTiles.Length; i++)
        {
            playerTiles[i] = gridPlayerParent.transform.GetChild(i).gameObject.GetComponent<Tile>();
        }

        for (int i = 0; i < idolsAmount; i++)
        {
            // TODO: add a check for if a tile is occupied already. Try searching for not occupied tile
            Tile randomTile = playerTiles[Random.Range(1, playerTiles.Length)];
            if (randomTile.isOccupied)
            {
                Debug.Log("PlayerTile is occpuied, trying new");
                i--;
                continue;               
            } else randomTile.isOccupied = true;

            // Haruka test spawn as players idol
            var harukaScriptable = ResourceSystem.Instance.GetIdolByName("Haruka");
            var spawned = Instantiate(harukaScriptable.Prefab, randomTile.transform.position, Quaternion.identity, randomTile.transform);
            spawned.name = "Haruka";
            var stats = harukaScriptable.BaseStats;
            spawned.SetStats(stats);
        }

    }

    private void SpawnEnemyIdols() // TODO: Remake so that it fetches the active player idol roster through scenes
    {
        EnemyTile[] enemyTiles = new EnemyTile[gridEnemyParent.transform.childCount];
        for (int i = 0; i < enemyTiles.Length; i++)
        {
            enemyTiles[i] = gridEnemyParent.transform.GetChild(i).gameObject.GetComponent<EnemyTile>();
        }

        for (int i = 0; i < idolsAmount; i++)
        {
            EnemyTile randomTile = enemyTiles[Random.Range(1, enemyTiles.Length)];
            if (randomTile.isOccupied)
            {
                Debug.Log("EnemyTile is occpuied, trying new");
                i--;
                continue;
            } else randomTile.isOccupied = true;
            // Iori test spawn as enemy
            var ioriScriptable = ResourceSystem.Instance.GetIdolByName("Iori");
            var spawned = Instantiate(ioriScriptable.Prefab, randomTile.transform.position, Quaternion.identity, randomTile.transform);
            spawned.name = "Iori";
            var stats = ioriScriptable.BaseStats;
            spawned.SetStats(stats);
        }
    }

    public void StartBattle()
    {
        battleStarted = true;
    }
}
