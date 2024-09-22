using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// TalentsListInitializer is responsible for loading all idols data into idols list in the HR panel.
/// </summary>
public class TalentsListInitializer : StaticInstance<TalentsListInitializer>
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
            Image[] idolImage = idolCell.GetComponentsInChildren<Image>(true); // TODO: PLACE IDOL ACCORDING IMAGE
            Button idolImageButton = idolCell.GetComponentInChildren<Button>(true);
            TextMeshProUGUI[] idolStrings = idolCell.GetComponentsInChildren<TextMeshProUGUI>(true);
            TextMeshProUGUI idolName = idolStrings[0];
            TextMeshProUGUI idolGenre = idolStrings[1];

            idolImage[1].sprite = ResourceSystem.Instance.Idols[i].IdolPFP;

            idolName.text = ResourceSystem.Instance.Idols[i].BaseStats.idolName;
            idolGenre.text = ResourceSystem.Instance.Idols[i].Bio.IdolGenre.ToString();

            idolImageButton.onClick.AddListener(delegate { IdolBioInitializer.Instance.ShowIdolBioPanel(idolName.text); }); // When you press the idols pfp the bio panel opens up fetching the idols stats
        }
    }
}
