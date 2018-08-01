using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour {

    public static MouseManager Instance { get; private set; }
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
        if (Input.GetMouseButtonDown(0)  ) // Left mouse button
        {
            if (MenuManager.Instance.isActive == true)
            {
                MenuManager.Instance.menuPanel.gameObject.SetActive(false);
                MenuManager.Instance.isActive = false;
                return;
            }

            // We have clicked on a hex, so do something
            MenuManager.Instance.SetCurrentHex(ourHitObject.GetComponent<HexTile>());
            MenuManager.Instance.menuPanel.gameObject.SetActive(true);
            // Open build menu
            Vector2 mousePosition = Input.mousePosition;
            Vector3 menuWorldPosition;
            RectTransformUtility.ScreenPointToWorldPointInRectangle(MenuManager.Instance.menuPanel, mousePosition, Camera.main, out menuWorldPosition);
            MenuManager.Instance.menuPanel.position = menuWorldPosition;
            MenuManager.Instance.isActive = true;
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