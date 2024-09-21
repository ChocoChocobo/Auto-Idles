using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// IdolBioInitializer is responsible for loading all data for a currently browsing idol in the Talent Seeking panel.
/// </summary>
public class IdolBioInitializer : StaticInstance<IdolBioInitializer>
{
    [SerializeField] private GameObject idolBioPanel;

    [Header("Bio Panel Attachables")]
    [SerializeField] private Image idolSprite;

    protected override void Awake()
    {
        base.Awake();
    }

    public void ShowIdolBioPanel(string idolName)
    {
        idolBioPanel.SetActive(true);
        //Debug.Log(idolName);
        var idolScriptable = ResourceSystem.Instance.GetIdolByName(idolName);

        idolSprite.sprite = idolScriptable.IdolInGameSprite;
    }
}
