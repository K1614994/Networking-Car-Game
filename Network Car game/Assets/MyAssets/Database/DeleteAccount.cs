using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteAccount : MonoBehaviour
{

    // create variables, text and buttons

    public Button submitButton;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoginPage"); // if no user has logged into the game send them back to the main menu (restricting access)
        }
    }

    public void CallDelete()
    {
        StartCoroutine(deleteAccount()); // when called start the coroutine
    }

    IEnumerator deleteAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username); // set the form to the DBManager variable
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/deleteAccount.php", form); // assign the web adress to the www type WWW
        yield return www;
        DBManager.Logout(); // call the log out function within the DBManager
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoginPage"); // load the main menu scene

    } // deletes the users account
}
