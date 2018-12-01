using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamePlate : MonoBehaviour {

    public string PlayerName { get; private set; }
    // create variables, text and buttons
    public TextMesh NameDisplay;

    // Use this for initialization
    void Start () {

        PlayerName = DBManager.username;
        NameDisplay.text = " " + PlayerName; // assign this text and variable to the .text
    }

}
