using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour {

    public Text WinStatus;
    public Text PointsCollected;
    public int test;
    GameManager gm; // Reference to the GameManager script
    // Use this for initialization
    void Start () {

        Debug.Log(DBManager.score);
       
        PointsCollected.text =  "You have collected " + DBManager.score + " points"; // assign this text and variable to the .text
        test = DBManager.tCollected;
        DBManager.tCollected = test + DBManager.score;
        if (DBManager.score > DBManager.hCollected)
        {
            DBManager.hCollected = DBManager.score;
        }

        if (DBManager.score > 1)
        {
            WinStatus.text = DBManager.username + " You have won the game "; // assign this text and variable to the .text
            DBManager.gamesPlayed = DBManager.gamesPlayed + 1;
            DBManager.gamesWon = DBManager.gamesWon + 1;
            CallWin();
        }
        else
        {
            WinStatus.text = DBManager.username + " You have lost the game "; // assign this text and variable to the .text
            DBManager.gamesPlayed = DBManager.gamesPlayed + 1;
            DBManager.gamesLost = DBManager.gamesLost + 1;
            CallLose();
        }
	}
    public void CallWin()
    {
  
        StartCoroutine(pushWin()); // when called start the coroutine
    }

    public void CallLose()
    {
       
        StartCoroutine(pushLose()); // when called start the coroutine
    }

    IEnumerator pushWin()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username); // set the form to the DBManager variable
        form.AddField("gamesPlayed", DBManager.gamesPlayed);
        form.AddField("gamesWon", DBManager.gamesWon);
        form.AddField("totalPoints", DBManager.tCollected); 
        form.AddField("highestPoints", DBManager.hCollected);
        form.AddField("averagePoints", DBManager.aCollected);
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/pushWin2.php", form); // assign the web adress to the www type WWW
        yield return www;
    }

    IEnumerator pushLose()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("gamesPlayed", DBManager.gamesPlayed);
        form.AddField("gamesLost", DBManager.gamesLost);
        form.AddField("totalPoints", DBManager.tCollected);
        form.AddField("highestPoints", DBManager.hCollected);
        form.AddField("averagePoints", DBManager.aCollected);
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/pushLose.php", form);
        yield return www;
  
    }

    public void Exit()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AccountPage");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
