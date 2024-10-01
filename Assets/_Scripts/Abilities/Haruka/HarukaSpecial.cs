using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HarukaSpecial : Ability
{
    public override void Activate(Transform targetTransform, int amount)
    {
        Debug.Log($"Haruka special attack activated for {amount}!");
    }
}
