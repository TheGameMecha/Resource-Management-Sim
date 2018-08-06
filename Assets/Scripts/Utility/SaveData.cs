using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public static SaveData current;
    public GridData grid;
    public ResourcesData resources;

    public SaveData()
    {
        grid = new GridData();
        resources = new ResourcesData
            (
                ResourceManager.Instance.currentCredits,
                ResourceManager.Instance.currentMetal,
                ResourceManager.Instance.currentGems,
                ResourceManager.Instance.currentPower,
                ResourceManager.Instance.currentFuel,

                ResourceManager.Instance.maxCredits,
                ResourceManager.Instance.maxMetal,
                ResourceManager.Instance.maxGems,
                ResourceManager.Instance.maxPower,
                ResourceManager.Instance.maxFuel
            );
    }

    public void UpdateAllData()
    {
        grid.UpdateGrid();
        resources.UpdateResources
            (
                ResourceManager.Instance.currentCredits,
                ResourceManager.Instance.currentMetal,
                ResourceManager.Instance.currentGems,
                ResourceManager.Instance.currentPower,
                ResourceManager.Instance.currentFuel,

                ResourceManager.Instance.maxCredits,
                ResourceManager.Instance.maxMetal,
                ResourceManager.Instance.maxGems,
                ResourceManager.Instance.maxPower,
                ResourceManager.Instance.maxFuel
            );
    }
}