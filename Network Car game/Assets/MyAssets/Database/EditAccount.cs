using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditAccount : MonoBehaviour
{

    // create variables, text and buttons
    public Text emailDisplay;
    public Text passwordDisplay;

    public InputField emailField;
    public InputField passwordField;

    public Button submitButton;

    private void Start()
    {
        emailDisplay.text = "Email: " + DBManager.email; // assign this text and variable to the .text
        passwordDisplay.text = "Password: ******** ";
    }
    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LoginPage"); // if no user has logged into the game send them back to the main menu (restricting access)
        }
   
    }

    public void CallEdit()
    {
        emailDisplay.text = "Email: " + DBManager.email; // assign this text and variable to the .text
        passwordDisplay.text = "Password: ******** ";
        StartCoroutine(editAccount()); // when called start the coroutine
    }

    IEnumerator editAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username); // set the form to the DBManager variable
        form.AddField("email", emailField.text); // set the form to the from the email input field
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/editAccount.php", form); // assign the web adress to the www type WWW
        yield return www;
        DBManager.Logout(); // call the logout function within the DBManager 
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoginPage"); // load the main menu scene

    }

    public void VerifyInputs()
    {
        submitButton.interactable = (emailField.text.Length >= 1 && emailField.text.Length <= 30 && passwordField.text.Length >= 1 && passwordField.text.Length <= 20); // make sure the input fields have atleast 8 characters within to enable the submit button
    }
}
