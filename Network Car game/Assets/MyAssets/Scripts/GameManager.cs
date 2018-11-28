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

    // Use this for initialization
    void Start()
    {
        timer = 100;
        score = 0;

        Collectables = GameObject.FindGameObjectsWithTag("Collectable");
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
            PhotonNetwork.LoadLevel(0);
        }

        if (timer == 90 || timer == 80 || timer == 70 || timer == 60 || timer == 50 || timer == 40)
        {
            var MyIndex = Random.Range(0, Collectables.Length);
            Collectables[MyIndex].SetActive(false);
        }


    }

    public void IncreaseScore()
    {
        score = score + 1;
    }
}
