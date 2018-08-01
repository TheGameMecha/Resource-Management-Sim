using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script that controls the Build Menu, where the player can select which building to make
public class BuildManager : MonoBehaviour {

    public static BuildManager Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;

    public RectTransform menuPanel;

    // An array of all the different building types
    // Used when building something
    public Building[] buildings;

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
    }

    // TODO: Make this method recieve a int variables to represent the desired building index
    public void BuildBuilding()
    {
        if (MenuManager.Instance.currentHex.isEmpty)
        {
            if (ResourceManager.Instance.currentCredits >= buildings[0].creditsCost)
            {
                // Update managers
                MenuManager.Instance.currentHex.isEmpty = false;
                ResourceManager.Instance.currentCredits -= buildings[0].creditsCost;

                // Spawn the building in
                Instantiate(buildings[0], MenuManager.Instance.currentHex.transform.position, Quaternion.identity, MenuManager.Instance.currentHex.transform);

                // Hide the menus
                MenuManager.Instance.menuPanel.gameObject.SetActive(false);
                MenuManager.Instance.isActive = false;
                menuPanel.gameObject.SetActive(false);
            }

        }
    }
}
