using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HarukaBasic : Ability
{
    public override void Activate(GameObject targetIdol, int amount)
    {
        targetIdol.GetComponent<IdolHealth>().TakeDamage(amount);
        Debug.Log($"Haruka basic attack activated for {amount}!");
    }
}
