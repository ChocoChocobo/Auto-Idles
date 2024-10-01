using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ability class is a base class for all the abilities.
/// </summary>
public class Ability : ScriptableObject
{
    public string abilityName;
    public string description;

    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(Transform targetTransform, int amount) { }
}
