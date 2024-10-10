using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// TimerManager class is responsible for timer logic at Night scene.
/// </summary>
public class TimerManager : StaticInstance<TimerManager>
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime; // In minutes

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (remainingTime > 0 && BattleInitializer.Instance.battleStarted) remainingTime -= Time.deltaTime;
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
            Debug.LogWarning("Time is up! idols head back to their studios!");
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
