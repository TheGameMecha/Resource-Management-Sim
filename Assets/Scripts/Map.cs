using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for generating a Hex based grid
public class Map : MonoBehaviour {

    [SerializeField]
    private GameObject hexPrefab;

    // Size of the map in terms of number of hex tiles
    // NOT representative of the world space amounts
    [SerializeField]
    private int width = 20;
    [SerializeField]
    private int height = 20;

    float xOffset = 0.882f;
    float zOffset = 0.764f;

	// Use this for initialization
	void Start ()
    {
        CreateGrid();
	}

    // Public method for generating a grid
    public void CreateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;
                // Are we on an odd row?
                if (y % 2 == 1) // if we are on an odd row, y mod 2 = 1
                {
                    xPos += xOffset / 2f; // Since we're on the odd row, we want to add half the offset
                }
                GameObject hex_go = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, y * zOffset), Quaternion.identity);

                // Name the gameobject based on its Coords
                hex_go.name = "Hex_" + x + "_" + y;

                // Assign its X and Y coords based on grid space, not world space
                hex_go.GetComponent<HexTile>().xPos = x;
                hex_go.GetComponent<HexTile>().yPos = y;

                // Make sure the object knows it is empty
                hex_go.GetComponent<HexTile>().isEmpty = true;

                // Set the object to be parented to the map GameObject. Just for a cleaner hierarchy
                hex_go.transform.SetParent(this.transform);

                // Set the object to be static for performance reasons
                hex_go.isStatic = true;

            }
        }
    }
}
