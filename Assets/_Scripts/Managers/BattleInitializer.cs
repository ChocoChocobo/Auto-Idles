using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BattleInitializer is a class that is responsible for pre battle initialization. I.e. placing enemies and lodaing your active idol roster
/// </summary>
public class BattleInitializer : MonoBehaviour
{
    // TODO: MAKE A RESOURCES MANAGeR THAT WOULD STORE ALL THE IDOLS
    [SerializeField] private ScriptableIdolBase[] scriptableIdol;
    [SerializeField] private IdolBase[] idolBase;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        // Haruka test spawn as players idol
        var spawned = Instantiate(scriptableIdol[0].prefab, spawnPoints[0].position, Quaternion.identity, spawnPoints[0]);
        spawned.name = "Haruka";
        var stats = scriptableIdol[0].BaseStats;
        spawned.SetStats(stats);

        // Iori test spawn as enemy
        var spawned1 = Instantiate(scriptableIdol[1].prefab, spawnPoints[1].position, Quaternion.identity, spawnPoints[1]);
        spawned1.name = "Iori";
        var stats1 = scriptableIdol[1].BaseStats;
        spawned1.SetStats(stats1);

        /*foreach (Transform spawns in spawnPoints)
        {
            var spawned = Instantiate(scriptableIdol.prefab, spawns.position, Quaternion.identity, spawns);
            var stats = scriptableIdol.BaseStats;
            spawned.SetStats(stats);
        }*/
    }
}
