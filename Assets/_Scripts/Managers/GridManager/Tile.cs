using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    public bool isOccupied = false;

    public void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    public void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        isOccupied = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        isOccupied = false; 
    }
}
