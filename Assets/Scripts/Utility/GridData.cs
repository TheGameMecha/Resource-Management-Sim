using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GridData
{
    public HexTileData[,] hexGrid;
    public int width;
    public int height;

    public GridData()
    {
        width = Map.Instance.GetWidth();
        height = Map.Instance.GetHeight();
        hexGrid = new HexTileData[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                hexGrid[x, y] = new HexTileData(x,y,true,-1);
            }
        }
    }

    public void UpdateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                hexGrid[x, y].xPos = Map.Instance.allTiles[x, y].xPos;
                hexGrid[x, y].yPos = Map.Instance.allTiles[x, y].yPos;
                hexGrid[x, y].isEmpty = Map.Instance.allTiles[x, y].isEmpty;
                hexGrid[x, y].currentBuilding = Map.Instance.allTiles[x, y].currentBuilding;
            }
        }
    }
}
