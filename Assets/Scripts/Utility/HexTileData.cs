using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class exists specifically to save and load data
[System.Serializable]
public class HexTileData {

    public int xPos;
    public int yPos;

    public bool isEmpty;

    public int currentBuilding;

    public HexTileData(int x, int y, bool empty, int building)
    {
        xPos = x;
        yPos = y;
        isEmpty = empty;
        currentBuilding = building;
    }

    public HexTileData()
    {
        xPos = 0;
        yPos = 0;
        isEmpty = true;
        currentBuilding = -1;
    }
}
