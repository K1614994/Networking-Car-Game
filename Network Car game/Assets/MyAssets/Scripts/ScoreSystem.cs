using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    // create variables, text and buttons
    public TextMesh scoreDisplay;

    // Use this for initialization
    void Start () {
        scoreDisplay.text = " " + DBManager.username + DBManager.score; // assign this text and variable to the .text
    }
	
	// Update is called once per frame
	void Update () {
        scoreDisplay.text = " " + DBManager.username + DBManager.score; // assign this text and variable to the .text
    }
}
