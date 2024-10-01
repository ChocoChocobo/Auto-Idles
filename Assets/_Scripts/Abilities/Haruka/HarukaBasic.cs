using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HarukaBasic : Ability
{
    public override void Activate(Transform targetTransform, int amount)
    {
        targetTransform.GetComponent<IdolHealth>().TakeDamage(amount);
        Debug.Log($"Haruka basic attack activated for {amount}!");
    }
}
