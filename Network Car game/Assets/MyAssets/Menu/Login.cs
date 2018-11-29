using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/Login.php", form);

        yield return www;
        if (www.text == "0")
        {
            DBManager.username = nameField.text;
            nameField.text = "";
            passwordField.text = "";
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }

        else
        {
            Debug.Log("User Login Failed. Error #" + www.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 1 && nameField.text.Length <= 30 && passwordField.text.Length >= 1 && passwordField.text.Length <= 20);
    }
}
