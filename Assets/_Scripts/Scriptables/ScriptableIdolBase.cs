using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewIdle")]
public class ScriptableIdolBase : ScriptableObject
{
    public Bio Bio;

    [SerializeField]
    private Stats stats;
    public Stats BaseStats => stats;

    //public IdolGenres IdolGenres;

    public IdolBase Prefab;

    public Sprite IdolPFP;
    public Sprite IdolInGameSprite;

    public bool IsOwned = false;
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

[Serializable]
public struct Bio
{
    public IdolGenre IdolGenre;
    public IdolType idolType;
    public string salaryExpectations;
    public string stageExperience;
    public string stageExpectations;
    public string description;
}

public enum IdolType
{
    Singer = 0,
    Dancer = 1,
    Instrument = 2
}

public enum IdolGenre
{
    Metal = 0,
    Indie = 1
}
