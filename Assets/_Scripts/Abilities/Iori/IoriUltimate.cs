using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IoriUltimate : Ability
{
    public override void Activate(Transform targetTransform, int amount)
    {
        Debug.Log($"Iori ultimate attack activated for {amount}!");
    }
}
