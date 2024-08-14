using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BattleInitializer is a class that is responsible for pre battle initialization. I.e. placing enemies and lodaing your active idol roster
/// </summary>
public class BattleInitializer : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        // Haruka test spawn as players idol
        var harukaScriptable = ResourceSystem.Instance.GetIdolByName("Haruka");
        var spawned = Instantiate(harukaScriptable.prefab, spawnPoints[0].position, Quaternion.identity, spawnPoints[0]);
        spawned.name = "Haruka";
        var stats = harukaScriptable.BaseStats;
        spawned.SetStats(stats);

        // Iori test spawn as enemy
        var ioriScriptable = ResourceSystem.Instance.GetIdolByName("Iori");
        var spawned1 = Instantiate(ioriScriptable.prefab, spawnPoints[1].position, Quaternion.identity, spawnPoints[1]);
        spawned1.name = "Iori";
        var stats1 = ioriScriptable.BaseStats;
        spawned1.SetStats(stats1);
    }
}
