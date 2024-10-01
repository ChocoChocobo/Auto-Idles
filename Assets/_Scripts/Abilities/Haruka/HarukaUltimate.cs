using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HarukaUltimate : Ability
{
    public override void Activate(Transform targetTransform, int amount)
    {
        Debug.Log($"Haruka ultimate attack activated for {amount}!");
    }
}
