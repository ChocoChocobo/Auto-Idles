using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// AbilityHolder class is a class responsible for storing an ability and its usage.
/// </summary>
public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    public float cooldownTime;
    private float activeTime;

    private bool isStarted = false;

    public AbilityState currentState = AbilityState.ready;

    private Stats stats;

    public GameObject targetIdol;

    private void Start()
    {
        stats = GetComponent<IdolBase>().stats;
        
    }

    private void Update()
    {
        activeTime -= Time.deltaTime;
        cooldownTime -= Time.deltaTime;

        switch (currentState)
        {
            case AbilityState.ready:
                if (isStarted)
                {
                    ability.Activate(targetIdol, stats.attackPower);
                    currentState = AbilityState.active;
                    activeTime = ability.activeTime;
                }
                
                break;
            case AbilityState.active:
                if (activeTime <= 0)
                {
                    currentState = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;
                    isStarted = false;
                }             

                break;
            case AbilityState.cooldown:
                if (cooldownTime <= 0) currentState = AbilityState.ready;                

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentState), currentState, "Ayo watch your ability!");
        }
    }

    // This function is called in the IdolBase state machine
    public void TriggerAbility()
    {
        isStarted = true;
    }

    public enum AbilityState
    {
        ready = 0,
        active = 1,
        cooldown = 2
    }
}
