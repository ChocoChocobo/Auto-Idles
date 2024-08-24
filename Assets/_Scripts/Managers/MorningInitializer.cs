using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// MorningInitializer is responsible for loading all the data at the start of the morning scene. I.e. loading all the data into HR panel.
/// </summary>
public class MorningInitializer : StaticInstance<MorningInitializer>
{
    [SerializeField] private GameObject idolListCellPrefab;
    [SerializeField] private GameObject idolsListPanel;

    protected override void Awake()
    {
        base.Awake();        
    }

    private void Start()
    {
        LoadIdolsToHire();
    }

    // Loading all the available idols into HR panel list for the current day
    // Storing a gameobject with idol cell and then filling the list in for loop < 4
    private void LoadIdolsToHire()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject idolCell = Instantiate(idolListCellPrefab, idolsListPanel.transform.position, Quaternion.identity, idolsListPanel.transform);
            Image idolImage = idolCell.GetComponentInChildren<Image>(true); // TODO
            TextMeshProUGUI[] idolsStats = idolCell.GetComponentsInChildren<TextMeshProUGUI>(true);
            TextMeshProUGUI idolName = idolsStats[0];
            TextMeshProUGUI idolGenre = idolsStats[1];

            idolName.text = ResourceSystem.Instance.Idols[i].BaseStats.idolName;
            idolGenre.text = ResourceSystem.Instance.Idols[i].IdolGenres.ToString();
        }
    }
}
