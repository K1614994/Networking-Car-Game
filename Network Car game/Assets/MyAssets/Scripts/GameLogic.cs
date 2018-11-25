using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

    float timer;
    public Text time;

	// Use this for initialization
	void Start () {
        timer = 15;
        
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timer = Mathf.Floor(timer * 100) / 100;
        time.text = timer.ToString();

        if (timer <= 0)
        {
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel(0);
        }
	}

    
}
