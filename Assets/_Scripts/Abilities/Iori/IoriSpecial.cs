using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IoriSpecial : Ability
{
    public override void Activate(Transform targetTransform, int amount)
    {
        Debug.Log($"Iori special attack activated for {amount}!");
    }
}
