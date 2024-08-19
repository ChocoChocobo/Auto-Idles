using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    public bool isOccupied = false;

    private int playerIdolLayer = 7;

    /*public void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    public void OnMouseExit()
    {
        
    }*/

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerIdolLayer)
        {
            highlight.SetActive(true);
            Debug.Log($"Tile occupied: {name}");
            // isOccupied = true;
        }
        else Debug.Log($"Not an idol layer: {other.name}");       
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == playerIdolLayer)
        {
            highlight.SetActive(false);
            Debug.Log($"Tile not occupied: {name}");
            //isOccupied = false;
        }
        else Debug.Log($"Not an idol layer: {other.name}");               
    }
}
