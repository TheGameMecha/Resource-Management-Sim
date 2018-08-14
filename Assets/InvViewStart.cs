using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvViewStart : MonoBehaviour {

    Scrollbar scrollbar;

	// Use this for initialization
	void Start () {
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.value = 0;
	}
	
}
