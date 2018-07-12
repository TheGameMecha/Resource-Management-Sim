using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Is the mouse over a Unity UI Element? -- Need to change if we want it to only affect buttons
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // It is, do nothing and return
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;
            Debug.Log("Raycast Hit: " + ourHitObject.name);

            // Check if we are over a Hex
            if (ourHitObject.GetComponent<HexTile>() != null)
            {
                MouseOverHex(ourHitObject);
            }
            else if (ourHitObject.GetComponent<Building>() != null)
            {
                MouseOverBuilding(ourHitObject);
            }

        }
	}

    public void MouseOverHex(GameObject ourHitObject)
    {
        // Functionality for Tile commands
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            // We have clicked on a hex, so do something
            HexTile currentHex = ourHitObject.GetComponent<HexTile>();
            Debug.Log("Clicked on tile: " + currentHex.xPos +", " + currentHex.yPos);
        }
    }

    public void MouseOverBuilding(GameObject ourHitObject)
    {
        // Functionality for selecting a building

        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {

        }
    }
}