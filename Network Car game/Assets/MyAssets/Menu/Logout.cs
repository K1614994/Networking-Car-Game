using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Logout : MonoBehaviour
{
    private void Awake()
    {
        if (DBManager.username == null)
        {
            SceneManager.LoadScene("LoginPage"); // if no user has logged into the game send them back to the main menu (restricting access)
        }
    }

    public void logout()
    {
        DBManager.Logout(); // call the log out function within the DBManager
        SceneManager.LoadScene("LoginPage"); // load the main menu scene
    }

}