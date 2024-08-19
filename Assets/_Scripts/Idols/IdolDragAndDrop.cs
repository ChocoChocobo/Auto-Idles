using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// IdolDragAndDrop script is responsible for managing player idols adjustments with collision layer IdolDrop
/// </summary>
public class IdolDragAndDrop : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Tile currentTile = null;
    private Vector3 initialPosition;

    private int tileLayer = 6;

    public void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPosition();
        initialPosition = transform.position;
        isDragging = true;
    }

    public void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;

        if (currentTile != null/* && !currentTile.isOccupied*/)
        {
            transform.position = currentTile.transform.position;
            currentTile.isOccupied = true;
        }
        else
        {
            Debug.LogWarning($"Current tile: {currentTile.name}");
            transform.position = initialPosition;
        }
        // TODO: snap back to the original position if no valid tile
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == tileLayer)
        {
            Debug.Log("Hit tile");

            Tile tile = other.GetComponent<Tile>();
            if (tile != null/* && !tile.isOccupied*/)
            {
                //tile.isOccupied = true;
                currentTile = tile;
                
            }
        }        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == tileLayer)
        {
            Tile tile = other.GetComponent<Tile>();
            
            if (tile != null/* && currentTile == tile*/)
            {
                tile.isOccupied = false;
                currentTile = null;
            }
        }
        
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
