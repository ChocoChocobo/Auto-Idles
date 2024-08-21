using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIdle")]
public class ScriptableIdolBase : ScriptableObject
{
    [SerializeField]
    private Stats stats;
    public Stats BaseStats => stats;

    public IdolBase prefab;

    public bool isActiveRoster = false;
}

[Serializable]
public struct Stats
{
    public string idleName;
    public float health;
    public float attackPower;
    public float attackRange;
    public float attackCooldown;
    public float specialAttackCooldown;
    public float moveSpeed;
    public bool isEnemy;
}
