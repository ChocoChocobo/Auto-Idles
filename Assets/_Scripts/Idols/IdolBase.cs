using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static AbilityHolder;

/// <summary>
/// IdolBase class is responsible for all the shared movement between idols. I.e. state machines for each idol.
/// </summary>
public class IdolBase : MonoBehaviour
{
    public Stats stats;
    public virtual void SetStats(Stats stats) => this.stats = stats;

    private IdolState currentState;

    public Transform targetTransform;

    /*private float basicAttackTimer;
    private float specialAttackTimer;
    private float ultimateAttackTimer;*/

    private Rigidbody2D rb;

    private AbilityHolder[] abilities;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        abilities = GetComponents<AbilityHolder>();
        Debug.Log($"Abilities loaded: {abilities.Length}");

        Debug.Log($"Idol initialized: {stats.idolName}, HP: {stats.health}, AP: {stats.attackPower}, Range: {stats.attackRange}");
        currentState = IdolState.Idle;

        if (stats.isEnemy) gameObject.tag = "EnemyIdol";
    }

    private void FixedUpdate()
    {
        HandleStates();

       /* basicAttackTimer -= Time.deltaTime;
        specialAttackTimer -= Time.deltaTime;
        ultimateAttackTimer -= Time.deltaTime;*/
    }

    private void HandleStates()
    {
        if (BattleInitializer.Instance.battleStarted)
        {
            //Debug.LogWarning($"Current state: {currentState}");
            switch (currentState)
            {
                case IdolState.Idle:
                    FindTarget();
                    break;
                case IdolState.Move:
                    MoveToTarget();
                    break;
                case IdolState.Attack:
                    AttackTarget();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, "Ayo watch your state!");
            }
        }        
    }

    private void FindTarget()
    {
        GameObject[] enemyIdols = GameObject.FindGameObjectsWithTag("EnemyIdol");
        GameObject[] playerIdols = GameObject.FindGameObjectsWithTag("PlayerIdol");
        Transform closestPlayerIdolPosition = null;
        Transform closestEnemyIdolPosition = null;
        float closestDistance = Mathf.Infinity;
        
        if (targetTransform == null)
        {
            switch (gameObject.tag)
            {
                case "EnemyIdol":
                    foreach (GameObject playerIdol in playerIdols)
                    {

                        float distance = Vector2.Distance(transform.position, playerIdol.transform.position);
                        //Debug.Log($"Distance is: {distance}");
                        if (distance < closestDistance)
                        {
                            closestPlayerIdolPosition = playerIdol.transform;
                            closestDistance = distance;
                            targetTransform = closestPlayerIdolPosition;
                            foreach (var ability in abilities)
                            {
                                ability.targetIdol = targetTransform.gameObject;
                            }
                        }
                    }
                    break;
                case "PlayerIdol":
                    foreach (GameObject enemyIdol in enemyIdols)
                    {

                        float distance = Vector2.Distance(transform.position, enemyIdol.transform.position);
                        //Debug.Log($"Distance is: {distance}");
                        if (distance < closestDistance)
                        {
                            closestEnemyIdolPosition = enemyIdol.transform;
                            closestDistance = distance;
                            targetTransform = closestEnemyIdolPosition;
                            foreach (var ability in abilities)
                            {
                                ability.targetIdol = targetTransform.gameObject;
                            }
                        }
                    }
                    break;
            }
        }
        else
        {
            Debug.Log($"Target found: {targetTransform.name}. Distance to the target is: {closestDistance}");
            currentState = IdolState.Move;
        }
    }

    private void MoveToTarget()
    {
        if (targetTransform == null)
        {
            currentState = IdolState.Idle;
            return;
        }

        Vector2 direction = (targetTransform.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * stats.moveSpeed * Time.deltaTime);
        float distanceToTarget = Vector2.Distance(transform.position, targetTransform.position);
        //Debug.Log($"Distance to target is: {distanceToTarget}");

        if (distanceToTarget <= stats.attackRange)
        {
            //Debug.Log("Idol is within attack range!");
            currentState = IdolState.Attack;
        }
    }

    private void AttackTarget()
    {
        if (targetTransform == null)
        {
            currentState = IdolState.Idle;
            return;
        }

        if (abilities[1].currentState != AbilityState.active && abilities[2].currentState != AbilityState.active)
        {
            abilities[0].TriggerAbility();

            if (abilities[0].currentState != AbilityState.active && abilities[2].currentState != AbilityState.active) abilities[1].TriggerAbility(); // special ability

            if (abilities[0].currentState == AbilityState.cooldown && abilities[1].currentState == AbilityState.cooldown) abilities[2].TriggerAbility(); // ultimate ability
        }// basic attack
         
        
        
        /*if (abilities[0].cooldownTime <= 0)
        {
            abilities[0].TriggerAbility();

            *//*targetTransform.GetComponent<IdolBase>().TakeDamage(stats.attackPower);
            Debug.Log($"Enemy attacked: {targetTransform.gameObject.name}");*//*
            //Debug.Log($"Enemy got: {stats.health}");
            //attackTimer = stats.attackCooldown; // REPLACE FROM ABILITY

            if (abilities[0].currentState == AbilityState.cooldown)
            {
                AttackTargetSpecial();
            }

            if (ultimateAttackTimer <= 0)
            {
                AttackTargetUltimate();
            }
        }*/
    }

    /*private void AttackTargetSpecial()
    {


        *//*targetTransform.GetComponent<IdolBase>().TakeDamage(stats.attackPower * 2); // TEST CHANGE LATER!
        Debug.Log($"Enemy attacked special: {targetTransform.gameObject.name}");*//*
        specialAttackTimer = stats.specialAttackCooldown; // REPLACE FROM ABILITY
    }

    private void AttackTargetUltimate()
    {
        *//*targetTransform.GetComponent<IdolBase>().TakeDamage(stats.attackPower * 3); // TEST CHANGE LATER!
        Debug.Log($"Enemy attacked special: {targetTransform.gameObject.name}");*//*
        ultimateAttackTimer = 
    }*/

    private void TakeDamage(float damage)
    {
        stats.health -= damage;

        if (stats.health < 0)
        {
            stats.health = 0;
            IdolDie();
        }
    }

    private void IdolDie()
    {
        Debug.LogError($"Idol {gameObject.name} died!");
        Destroy(gameObject);
    }

    [Serializable]
    public enum IdolState
    {
        Idle,
        Move,
        Attack,
    }










    /*private void Start()
    {
        attackTimer = stats.attackCooldown;
        specialAttackTimer = stats.specialAttackCooldown;

        currentState = IdolState.Idle;
        rb = GetComponent<Rigidbody2D>();

        if (stats.isEnemy) tag = "EnemyIdol";
        else tag = "PlayerIdol";


    }

    private void Update()
    {
        UpdateState();

        attackTimer -= Time.deltaTime;
        specialAttackTimer -= Time.deltaTime;
    }

    *//*public void InitializeIdol(Stats idolStats)
    {
        stats = idolStats;
    }*//*

    private void UpdateState()
    {
        //Debug.Log($"Idol {gameObject.name} state: {currentState}");
        switch (currentState)
        {
            case IdolState.Idle:
                FindTarget();
                break;
            case IdolState.Move:
                MoveToTarget();
                break;
            case IdolState.Attack:
                AttackTarget();
                break;
            case IdolState.SpecialAttack:
                SpecialAttack();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentState), currentState, "Ayo watch your state!");
        }
    }

    private void FindTarget()
    {
        GameObject[] enemiesToChooseFrom = GameObject.FindGameObjectsWithTag("PlayerIdol");
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        //Debug.Log($"Closest distance: {closestDistance}");

        foreach(GameObject enemyIdol in enemiesToChooseFrom)
        {
            float distance = Vector3.Distance(transform.position, enemyIdol.transform.position);
            Debug.Log($"Distance calculated: {distance}");
            if (distance < closestDistance)
            {
                closestEnemy = enemyIdol;
                closestDistance = distance;
                targetPosition = enemyIdol.transform;
            }
        }

        if (targetPosition != null)
        {
            currentState = IdolState.Move;
        }
    }

    private void MoveToTarget()
    {
        if (targetPosition == null)
        {
            currentState = IdolState.Idle;
            return;
        }

        Vector2 direction = (targetPosition.position - transform.position).normalized;
        rb.velocity += direction * stats.moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition.position) <= stats.attackRange)
        {
            currentState = IdolState.Attack;
        }
    }

    private void AttackTarget()
    {
        if (targetPosition == null)
        {
            currentState = IdolState.Idle;
            return;
        }

        if (attackTimer <= 0)
        {
            targetPosition.GetComponent<IdolBase>().TakeDamage(stats.attackPower);
            //Debug.Log($"Enemy attacked for: {stats.attackPower}");
            //Debug.Log($"Enemy got: {stats.health}");
            attackTimer = stats.attackCooldown;

            if (specialAttackTimer <= 0)
            {
                currentState = IdolState.SpecialAttack;
            }
        }
    }

    private void SpecialAttack()
    {
        if (targetPosition == null)
        {
            currentState = IdolState.Idle;
            return;
        }

        targetPosition.GetComponent<IdolBase>().TakeDamage(stats.attackPower * 2); // TEST CHANGE LATER!
        specialAttackTimer = stats.specialAttackCooldown;

        currentState = IdolState.Idle;
    }

    private void TakeDamage(float damage)
    {
        stats.health -= damage;

        if (stats.health <= 0)
        {
            stats.health = 0;
            IdolDie();
        }
    }

    private void IdolDie()
    {
        // Logic for an idol unable to continue
        //      For now just simply delete for tests
        Debug.LogWarning("IDOL DIED");
        Destroy(gameObject);
    }
}*/
}