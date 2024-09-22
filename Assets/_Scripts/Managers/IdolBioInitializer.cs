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
    [SerializeField] private TextMeshProUGUI idolNameText;
    [SerializeField] private TextMeshProUGUI genreType;
    [SerializeField] private TextMeshProUGUI salaryExpectations;
    [SerializeField] private TextMeshProUGUI stageExpreience;
    [SerializeField] private TextMeshProUGUI stageExpectations;
    [SerializeField] private TextMeshProUGUI idolDescription;
    [SerializeField] private GameObject idolSkillsParent;

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
        idolNameText.text = idolScriptable.BaseStats.idolName;
        genreType.text = $"{idolScriptable.Bio.IdolGenre} | {idolScriptable.Bio.idolType}";
        salaryExpectations.text = idolScriptable.Bio.salaryExpectations;
        stageExpreience.text = idolScriptable.Bio.stageExperience;
        stageExpectations.text = idolScriptable.Bio.stageExpectations;
        idolDescription.text = idolScriptable.Bio.description;
    }
}
