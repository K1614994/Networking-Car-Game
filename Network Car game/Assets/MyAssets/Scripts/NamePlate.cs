using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {

    // create variables, text and buttons
    public TextMesh NameDisplay;

    // Use this for initialization
    void Start () {
        NameDisplay.text = " " + DBManager.username; // assign this text and variable to the .text
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
