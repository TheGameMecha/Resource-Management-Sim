using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used for controlling the popup menus
[RequireComponent(typeof(RectTransform))]
public class MenuManager : MonoBehaviour {

    public static MenuManager Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;
    public RectTransform menuPanel;
    [HideInInspector]
    public HexTile currentHex;

    [HideInInspector]
    public bool isActive = false;

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

    public void SetCurrentHex(HexTile hex)
    {
        currentHex = hex;
    }

    public void OpenBuildMenu()
    {
        BuildManager.Instance.menuPanel.gameObject.SetActive(true);
    }
}
