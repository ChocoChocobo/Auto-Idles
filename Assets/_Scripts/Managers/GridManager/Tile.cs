using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject highlight;

    public void OnMouseEnter()
    {
        highlight.SetActive(true);
    }

    public void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
