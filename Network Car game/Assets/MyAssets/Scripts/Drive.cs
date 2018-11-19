﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Drive : Photon.MonoBehaviour {

    private PhotonView PhotonView;
    private Vector3 TargetPosition;
    private Quaternion TargetRotation;
    

    private void Awake()
    {
        PhotonView = GetComponent<PhotonView>();
        if(PhotonView.isMine)
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
        }
        else
        {
            this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
        }
    }

    

    // Update is called once per frame
    void Update () {
        if (PhotonView.isMine)
        {
            //this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
            CheckInput();
        }
        else
        {
           // this.transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = false;
            SmoothMove();
        }
        //float translation = CrossPlatformInputManager.GetAxis("Vertical") * -speed;
        //float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;

        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);

	}

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            TargetPosition = (Vector3)stream.ReceiveNext();
            TargetRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    private void SmoothMove()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.25f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, 500 * Time.deltaTime);
    }

    private void CheckInput()
    {
        float speed = 10.0f;
        float rotationSpeed = 100.0f;

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.position += transform.forward * (vertical * -speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontal * rotationSpeed * Time.deltaTime, 0));
    }
}
