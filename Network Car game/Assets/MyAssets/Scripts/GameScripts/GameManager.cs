using System.Collections;
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

        if (timer <= 50)
        {
            //var MyIndex = Random.Range(0, Collectables5.Length);
            Collectables5[0].GetComponent<MeshRenderer>().enabled = false; 
            Collectables5[0].GetComponent<SphereCollider>().enabled = false;
            
        }
         

        //if (timer == 70)
        //{
        //    var MyIndex5 = Random.Range(0, Collectables5.Length);
        //    Collectables[MyIndex5].SetActive(false);
        //}


    }

    public void IncreaseScore()
    {
        score = score + 1;
        DBManager.score = score;
    }

    public void IncreaseScore5()
    {
        score = score + 5;
        DBManager.score = score;
    }

    public void IncreaseTime()
    {
        timer = timer + 10;
    }

   
}
