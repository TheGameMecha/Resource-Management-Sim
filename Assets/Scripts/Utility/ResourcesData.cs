using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class for storing the resources in the Save Data
[System.Serializable]
public class ResourcesData
{
    public int currentCredits;
    public int currentMetal;
    public int currentGems;
    public int currentPower;
    public int currentFuel;

    public int maxCredits;
    public int maxMetal;
    public int maxGems;
    public int maxPower;
    public int maxFuel;

    public ResourcesData(int credits, int metal, int gems, int power, int fuel, int m_credits, int m_metal, int m_gems, int m_power, int m_fuel)
    {
        // Current values
        currentCredits = credits;
        currentMetal = metal;
        currentGems = gems;
        currentPower = power;
        currentFuel = fuel;

        // Max values
        maxCredits = m_credits;
        maxMetal = m_metal;
        maxGems = m_gems;
        maxPower = m_power;
        maxFuel = m_fuel;
    }

    public void UpdateResources(int credits, int metal, int gems, int power, int fuel, int m_credits, int m_metal, int m_gems, int m_power, int m_fuel)
    {
        // Current values
        currentCredits = credits;
        currentMetal = metal;
        currentGems = gems;
        currentPower = power;
        currentFuel = fuel;

        // Max values
        maxCredits = m_credits;
        maxMetal = m_metal;
        maxGems = m_gems;
        maxPower = m_power;
        maxFuel = m_fuel;
    }
}