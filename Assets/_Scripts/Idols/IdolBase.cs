using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static AbilityHolder;

/// <summary>
/// IdolBase class is responsible for idol states.
/// </summary>
public class IdolBase : MonoBehaviour
{
    public Stats stats;
    public virtual void SetStats(Stats stats) => this.stats = stats;

    private IdolState currentState;

    public Transform targetTransform;

    private Rigidbody2D rb;

    private AbilityHolder[] abilities;

    private const string PLAYER_IDOL_TAG = "PlayerIdol";
    private const string ENEMY_IDOL_TAG = "EnemyIdol";

    private void Start()
    {
        TirednessMeter.FightEnded += GoHome;

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
    }

    private void HandleStates()
    {
        Debug.Log(currentState);
        if (BattleInitializer.Instance.battleStarted)
        {
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
                case IdolState.GoHome:
                    GoHome();
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
                case ENEMY_IDOL_TAG:
                    foreach (GameObject playerIdol in playerIdols)
                    {

                        float distance = Vector2.Distance(transform.position, playerIdol.transform.position);
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
                case PLAYER_IDOL_TAG:
                    foreach (GameObject enemyIdol in enemyIdols)
                    {

                        float distance = Vector2.Distance(transform.position, enemyIdol.transform.position);
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


        if (distanceToTarget <= stats.attackRange)
        {
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
    }

    private void GoHome()
    {
        currentState = IdolState.GoHome;

        if (TrackIdolsOnScreen.Instance.idolsOnScreen == 0)
        {
            TirednessMeter.FightEnded -= GoHome;
            BattleInitializer.Instance.battleStarted = false;
            currentState = IdolState.Idle; // Leave it like that just for the sake of them doing nothing kinda
            Debug.LogError("Loading screen goes to Morning...");
        }

        switch (gameObject.tag)
        {
            case ENEMY_IDOL_TAG:
                HandleHomeMovement(1);
                break;
            case PLAYER_IDOL_TAG:
                HandleHomeMovement(-1);
                break;
            default:
                throw new ArgumentOutOfRangeException(gameObject.tag, gameObject.tag, "Ayo watch your movement!");
        }
    }

    private void HandleHomeMovement(float direction)
    {
        rb.velocity += stats.moveSpeed * new Vector2(direction, 0) * Time.deltaTime;
    }

    [Serializable]
    public enum IdolState
    {
        Idle,
        Move,
        Attack,
        GoHome
    }
}