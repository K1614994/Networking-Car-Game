﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabAccountStats : MonoBehaviour {

    public string nameField;
    public Text userNameField;
    public Text Email;
    public Text Email2;
    public Text CarC;
    public Text gamesWon;
    public Text gamesLost;
    public Text gamesPlayed;
    public Text tCollected;
    public Text hCollected;
    public Text aCollected;

    IEnumerator Start()
    {
        nameField = DBManager.username;
        WWWForm form = new WWWForm();
        form.AddField("name", nameField);
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/grabData.php", form);
        yield return www;
        string[] webResults = www.text.Split('\t');
        foreach (string s in webResults)
        {
            Debug.Log(s);
        }

        userNameField.text = "Username: " + DBManager.username;
        DBManager.email = (webResults[0]);
        Email.text = "Email: " + DBManager.email;
        Email2.text = "Email: " + DBManager.email;
        DBManager.carColour = int.Parse(webResults[1]);
        CarC.text = "Car Colour: " + DBManager.carColour;
        DBManager.gamesPlayed = int.Parse(webResults[2]);
        gamesPlayed.text = "Games Played: " + DBManager.gamesPlayed;
        DBManager.gamesWon = int.Parse(webResults[3]);
        gamesWon.text = "Games Won: " + DBManager.gamesWon;
        DBManager.gamesLost = int.Parse(webResults[4]);
        gamesLost.text = "Games Lost: " + DBManager.gamesLost;
        DBManager.tCollected = int.Parse(webResults[5]);
        tCollected.text = "Total Points Collected: " + DBManager.tCollected;
        DBManager.hCollected = int.Parse(webResults[6]);
        hCollected.text = "Highest Points Collected: " + DBManager.hCollected;
        DBManager.pTotalCollected = int.Parse(webResults[7]);
        aCollected.text = "Power Ups Collected: " + DBManager.pTotalCollected;
    }
}