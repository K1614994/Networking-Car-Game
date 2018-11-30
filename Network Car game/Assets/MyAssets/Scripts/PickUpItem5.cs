using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem5 : MonoBehaviour {

    GameManager gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            gm.IncreaseScore5();
        }
    }
}
