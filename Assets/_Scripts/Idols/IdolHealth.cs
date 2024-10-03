using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdolHealth : MonoBehaviour
{
    //private Slider healthBar;

    private float health;
    private float maxHealth;

    private bool isBlocking = false;

    private void Start()
    {
        health = GetComponent<IdolBase>().stats.health;
        maxHealth = health;

    }

    public float GetHealth()
    {
        return health;
    }

    public bool GetBlockStatus()
    {
        return isBlocking;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        //healthBar.value = health;
        Debug.LogWarning($"{gameObject.name} health is {health}");
        if (health <= 0) Debug.LogWarning($"{gameObject.name} is down!");
        if (health < 0) health = 0;
    }

    public void TakeHeal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth) health = maxHealth;
        //healthBar.value = health;
    }

    // TakeBlock()

    // DisableBlock()
}
