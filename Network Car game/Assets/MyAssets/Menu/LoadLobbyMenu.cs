using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLobbyMenu : MonoBehaviour {

    public void LoadLobby()
    {
        SceneManager.LoadScene("PhotonLobby2");
    }
}
