using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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


    public static Map Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;

    [HideInInspector]
    public HexTile[,] allTiles;

    // Called on object creation
    void Awake()
    {
        // Singleton pattern
        // Makes sure there is only ever one GameManager object
        // Since we store data in this, we need to make sure it is used in the preload scene ONLY
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject);
        }

        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(gameObject); // Keep the only manager alive across scenes
        }

         allTiles = new HexTile[width, height];
    }

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

                allTiles[x, y] = hex_go.GetComponent<HexTile>();
                
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                allTiles[x,y].GetNeighbors();
            }
        }
    }
}
