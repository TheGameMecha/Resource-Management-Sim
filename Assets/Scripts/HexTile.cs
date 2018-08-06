using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HexTile : MonoBehaviour
{
    // Coords in the map array
    public int xPos;
    public int yPos;

    [HideInInspector]
    public bool isEmpty = true;

    public List<HexTile> neighbors;

    public int currentBuilding = -1;

    public void GetNeighbors()
    {
        // Hexes are weird so we need to check if the Y position is even or odd to determine its neighbors
        if (yPos % 2 == 0) // Check if Y is even
        {
            EvenNeighbors();
        }
        else
        {
            OddNeighbors();
        }
    }

    public void EvenNeighbors()
    {
        if (xPos - 1 >= 0 && yPos - 1 >= 0)
        {
            if (Map.Instance.allTiles[xPos - 1, yPos - 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos - 1, yPos - 1]);
            }
        }

        if (yPos - 1 >= 0)
        {
            if (Map.Instance.allTiles[xPos, yPos - 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos, yPos - 1]);
            }
        }

        if (xPos - 1 >= 0)
        {
            if (Map.Instance.allTiles[xPos - 1, yPos] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos - 1, yPos]);
            }
        }

        if (xPos + 1 < Map.Instance.allTiles.GetLength(0))
        {
            if (Map.Instance.allTiles[xPos + 1, yPos] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos + 1, yPos]);
            }
        }

        if (xPos - 1 >= 0 && yPos + 1 < Map.Instance.allTiles.GetLength(1))
        {
            if (Map.Instance.allTiles[xPos - 1, yPos + 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos - 1, yPos + 1]);
            }
        }

        if (yPos + 1 < Map.Instance.allTiles.GetLength(1))
        {
            if (Map.Instance.allTiles[xPos, yPos + 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos, yPos + 1]);
            }
        }
    }

    public void OddNeighbors()
    {
        if (yPos - 1 >= 0)
        {
            if (Map.Instance.allTiles[xPos, yPos - 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos, yPos - 1]);
            }
        }

        if (xPos + 1 < Map.Instance.allTiles.GetLength(0) && yPos - 1 >= 0)
        {
            if (Map.Instance.allTiles[xPos + 1, yPos - 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos + 1, yPos - 1]);
            }
        }

        // Checks 1 to the left
        if (xPos - 1 >= 0)
        {
            if (Map.Instance.allTiles[xPos - 1, yPos] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos - 1, yPos]);
            }
        }

        // Grabs 1 to the left
        if (xPos + 1 < Map.Instance.allTiles.GetLength(0))
        {
            if (Map.Instance.allTiles[xPos + 1, yPos] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos + 1, yPos]);
            }
        }

        // Checks 1 above
        if (yPos + 1 < Map.Instance.allTiles.GetLength(1))
        {
            if (Map.Instance.allTiles[xPos, yPos + 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos, yPos + 1]);
            }
        }

        if (xPos + 1 < Map.Instance.allTiles.GetLength(0) && yPos + 1 < Map.Instance.allTiles.GetLength(1))
        {
            if (Map.Instance.allTiles[xPos + 1, yPos + 1] != null)
            {
                neighbors.Add(Map.Instance.allTiles[xPos + 1, yPos + 1]);
            }
        }
    }
}
