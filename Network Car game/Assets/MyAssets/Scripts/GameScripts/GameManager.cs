﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    float timer;
    public Text time;
    public int score;
    public Text scoreT;
   

    GameObject[] Collectables;
    GameObject[] Collectables5;

    // Use this for initialization
    void Start()
    {
        DBManager.score = 0;
        timer = 60;

        
        Collectables = GameObject.FindGameObjectsWithTag("Collectable") ;
        Collectables5 = GameObject.FindGameObjectsWithTag("Collectable5");
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Floor(timer * 100) / 100;
        time.text = timer.ToString();

        scoreT.text = score.ToString();
        

        if (timer <= 0)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("GameOverMenu");
        }

        
         

       


    }

    public void IncreaseScore()
    {
        score = score + 1;
        DBManager.score = score;
    }

    public void IncreaseScore5()
    {
        score = score + 5;
        DBManager.pTotalCollected = DBManager.pTotalCollected + 1 ;
        DBManager.score = score;
    }

    public void IncreaseTime()
    {
        DBManager.pTotalCollected = DBManager.pTotalCollected + 1;
        timer = timer + 10;
    }

   
}
