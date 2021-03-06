﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager Instance { get; private set; }
    [SerializeField]
    private bool dontDestroyOnLoad = true;

    [Header("Resources")]
    public int currentCredits = 1000;
    public int maxCredits;

    public int currentMetal = 500;
    public int maxMetal;

    public int currentGems = 0;
    public int maxGems = 999;

    public int currentPower = 100;
    public int maxPower;

    public int currentFuel = 100;
    public int maxFuel;

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
}