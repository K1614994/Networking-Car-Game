using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LocalPlayerSetUp : NetworkBehaviour {

    [SyncVar]
    public string pname = "Player";

    [SyncVar]
    public Color playerColor = Color.white;

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pname);
            if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Change"))
            {
                CmdChangeName(pname);
            }
        }
    }

        [Command]
        public void CmdChangeName(string newName)
    {
        pname = newName;
    }
    // Use this for initialization
    void Start () {

        if (isLocalPlayer)
        {
            GetComponent<Drive>().enabled = true;
            //SmoothCameraFollow.target = this.transform;

            Camera.main.transform.position = this.transform.position - this.transform.forward * -10 + this.transform.up * 7;
            Camera.main.transform.LookAt(this.transform.position);
            Camera.main.transform.parent = this.transform;
        }

            Renderer[] rends = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in rends)
                r.material.color = playerColor;

        this.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
	}

    void Update()
    {
        
            this.GetComponentInChildren<TextMesh>().text = pname;
    }

}
