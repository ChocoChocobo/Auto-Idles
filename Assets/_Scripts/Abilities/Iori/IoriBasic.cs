using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IoriBasic : Ability
{
    public override void Activate(Transform targetTransform, int amount)
    {
        targetTransform.GetComponent<IdolHealth>().TakeDamage(amount);
        Debug.Log($"Iori basic attack activated for {amount}!");
    }
}
