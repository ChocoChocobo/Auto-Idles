using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

/// <summary>
/// TimerManager class is responsible for timer logic at Night scene.
/// </summary>
public class TirednessMeter : StaticInstance<TirednessMeter>
{
    //[SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Slider tirednessSlider;
    [SerializeField] private float remainingTime; // In minutes
    public static event Action FightEnded;

    protected override void Awake()
    {
        base.Awake();
        tirednessSlider.value = remainingTime;
    }

    private void Update()
    {
        if (remainingTime > 0 && BattleInitializer.Instance.battleStarted)
        {
            remainingTime -= Time.deltaTime;
            tirednessSlider.value = remainingTime;
        }
        else if (remainingTime < 0 && TrackIdolsOnScreen.Instance.idolsOnScreen > 0)
        {
            remainingTime = 0;
            FightEnded?.Invoke();
            //timerText.color = Color.red;
            Debug.LogWarning("Time is up! idols head back to their studios!");
        }
        /*int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);*/
    }
}
