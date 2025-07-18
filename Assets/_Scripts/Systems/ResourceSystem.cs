using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// ResourceSystem class is a repository for all scriptable objects. Here we create all the necessary queries to get scriptables
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem>
{
    public List<ScriptableIdolBase> Idols { get; private set; }
    private Dictionary<string, ScriptableIdolBase> IdolDict;

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        Idols = Resources.LoadAll<ScriptableIdolBase>("Idols").ToList();
        IdolDict = Idols.ToDictionary(i => i.prefab.name, i => i);

        Debug.Log($"idols assembled: {Idols.Count}");
    }

    // Getting idol by name of the prefab
    public ScriptableIdolBase GetIdolByName(string idolName) => IdolDict[idolName];
}
