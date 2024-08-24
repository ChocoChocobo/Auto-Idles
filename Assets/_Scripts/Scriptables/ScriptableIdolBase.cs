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

    public IdolGenres IdolGenres;

    public IdolBase Prefab;

    public bool IsActiveRoster = false;
}

[Serializable]
public struct Stats
{
    public string idolName;
    public float health;
    public float attackPower;
    public float attackRange;
    public float attackCooldown;
    public float specialAttackCooldown;
    public float moveSpeed;
    public bool isEnemy;
}

public enum IdolGenres
{
    Metal = 0,
    Indie = 1
}
