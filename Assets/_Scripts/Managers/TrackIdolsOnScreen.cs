using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackIdolsOnScreen : StaticInstance<TrackIdolsOnScreen>
{    
    public int idolsOnScreen;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerIdol") || other.gameObject.CompareTag("EnemyIdol"))
        {
            idolsOnScreen++;
            Debug.Log($"Idol entered: {idolsOnScreen}");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerIdol") || other.gameObject.CompareTag("EnemyIdol"))
        {
            idolsOnScreen--;
            Debug.Log($"Idol left: {idolsOnScreen}");
        }
    }
}
