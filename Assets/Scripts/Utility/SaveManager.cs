using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;

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

        Debug.Log(Application.persistentDataPath);
    }

    // Load game attempts to rebuild the games' state based on save data
    public void LoadGame ()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            Debug.Log("Save Data Found! Now Loading...");
        }
        else
        {
            Debug.Log("No Save Data Found, Creating new File...");
            FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
            file.Close();

            SaveData.current = new SaveData();
            SaveData.current.grid.UpdateGrid();
            SaveGame();

            return;
        }

        // Loads the data from file
        SaveLoad.Load();

        // Load the Grid and spawn the buildings
        for (int x = 0; x < Map.Instance.GetWidth(); x++)
        {
            for (int y = 0; y < Map.Instance.GetHeight(); y++)
            {
                Debug.Log(SaveData.current.ToString());
                // Update the internal grid based on save data
                Map.Instance.allTiles[x, y].xPos = SaveData.current.grid.hexGrid[x, y].xPos;
                Map.Instance.allTiles[x, y].yPos = SaveData.current.grid.hexGrid[x, y].yPos;
                Map.Instance.allTiles[x, y].isEmpty = SaveData.current.grid.hexGrid[x, y].isEmpty;
                Map.Instance.allTiles[x, y].currentBuilding = SaveData.current.grid.hexGrid[x, y].currentBuilding;

                // Spawn all buildings that exist
                // Any Hex that has "current building" set to -1 is a hex without a current building
                if (Map.Instance.allTiles[x, y].currentBuilding >= 0)
                {
                    Instantiate(BuildManager.Instance.buildings[Map.Instance.allTiles[x, y].currentBuilding], Map.Instance.allTiles[x,y].transform.position, Quaternion.identity, Map.Instance.allTiles[x,y].transform);
                }
            }
        }

        // Load Resources and assign them to the ResourceManager
        ResourceManager.Instance.currentCredits = SaveData.current.resources.currentCredits;
        ResourceManager.Instance.maxCredits = SaveData.current.resources.maxCredits;

        ResourceManager.Instance.currentMetal = SaveData.current.resources.currentMetal;
        ResourceManager.Instance.maxMetal = SaveData.current.resources.maxMetal;

        ResourceManager.Instance.currentGems = SaveData.current.resources.currentGems;
        ResourceManager.Instance.maxGems = SaveData.current.resources.maxGems;

        ResourceManager.Instance.currentPower = SaveData.current.resources.currentPower;
        ResourceManager.Instance.maxPower = SaveData.current.resources.maxPower;

        ResourceManager.Instance.currentFuel = SaveData.current.resources.currentFuel;
        ResourceManager.Instance.maxFuel = SaveData.current.resources.maxFuel;
    }

    // Save the game when the player quits
    public void SaveGame()
    {
        SaveData.current.UpdateAllData();
        SaveLoad.Save();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}