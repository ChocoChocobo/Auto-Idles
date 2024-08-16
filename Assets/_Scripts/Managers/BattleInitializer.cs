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
        GameObject[] playerTiles = new GameObject[gridPlayerParent.transform.childCount];
        for (int i = 0; i < playerTiles.Length; i++)
        {
            playerTiles[i] = gridPlayerParent.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < idolsAmount; i++)
        {
            // TODO: add a check for if a tile is occupied already. Try searching for not occupied tile
            GameObject randomTile = playerTiles[Random.Range(1, playerTiles.Length)];
            // Haruka test spawn as players idol
            var harukaScriptable = ResourceSystem.Instance.GetIdolByName("Haruka");
            var spawned = Instantiate(harukaScriptable.prefab, randomTile.transform.position, Quaternion.identity, randomTile.transform);
            spawned.name = "Haruka";
            var stats = harukaScriptable.BaseStats;
            spawned.SetStats(stats);
        }

    }

    private void SpawnEnemyIdols() // TODO: Remake so that it fetches the active player idol roster through scenes
    {
        GameObject[] enemyTiles = new GameObject[gridEnemyParent.transform.childCount];
        for (int i = 0; i < enemyTiles.Length; i++)
        {
            enemyTiles[i] = gridEnemyParent.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < idolsAmount; i++)
        {
            GameObject randomTile = enemyTiles[Random.Range(1, enemyTiles.Length)];
            // Iori test spawn as enemy
            var ioriScriptable = ResourceSystem.Instance.GetIdolByName("Iori");
            var spawned = Instantiate(ioriScriptable.prefab, randomTile.transform.position, Quaternion.identity, randomTile.transform);
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
