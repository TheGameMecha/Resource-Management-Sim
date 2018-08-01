using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script used for updating the UI elements for Resources
public class ResourceCanvas : MonoBehaviour {
    [SerializeField]
    private Text creditsText;
    [SerializeField]
    private Text metalText;
	
	// Update is called once per frame
	void Update ()
    {
        creditsText.text = ResourceManager.Instance.currentCredits.ToString();
        metalText.text = ResourceManager.Instance.currentMetal.ToString();
	}
}
