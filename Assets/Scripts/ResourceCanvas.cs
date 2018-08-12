using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script used for updating the UI elements for Resources
public class ResourceCanvas : MonoBehaviour {
    public static ResourceCanvas Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;

    [Header("UI")]
    [SerializeField]
    private Text creditsText;
    [SerializeField]
    private Text metalText;

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

    public void UpdateUI()
    {
        creditsText.text = ResourceManager.Instance.currentCredits.ToString();
        metalText.text = ResourceManager.Instance.currentMetal.ToString();
    }
}