using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

    [SerializeField]
    private GameObject buildingModel;

    [Header("Resource Costs")]
    public int creditsCost = 100;
    public int metalCost = 100;

    private HexTile tile;

	// Use this for initialization
	void Awake () {
        tile = GetComponentInParent<HexTile>();
        if (buildingModel)
        {
            Instantiate(buildingModel, transform);
        }
	}
}
