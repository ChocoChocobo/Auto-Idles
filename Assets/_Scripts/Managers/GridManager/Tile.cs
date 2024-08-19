using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    public bool isOccupied = false;

    private int playerIdolLayer = 7;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerIdolLayer)
        {
            highlight.SetActive(true);
        }      
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == playerIdolLayer)
        {
            highlight.SetActive(false);
        }              
    }
}
