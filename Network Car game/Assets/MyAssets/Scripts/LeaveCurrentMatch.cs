﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveCurrentMatch : MonoBehaviour {

public void OnClick_LeaveMatch()
    {
        PhotonNetwork.LoadLevel("PhotonLobby2");
        PhotonNetwork.LeaveRoom();

    }
}
