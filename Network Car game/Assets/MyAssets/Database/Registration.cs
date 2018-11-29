using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField emailField;
    public InputField passwordField;

    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/Register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User Created Successfully");
            UnityEngine.SceneManagement.SceneManager.LoadScene("Login");
            nameField.text = "";
            emailField.text = "";
            passwordField.text = "";

        }
        else
        {
            Debug.Log("User Creation Failed. Error #" + www.text);
        }
    }


    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 1 && nameField.text.Length <= 30 && passwordField.text.Length >= 1 && passwordField.text.Length <= 20 && emailField.text.Length >= 1 && emailField.text.Length <= 30);
    }
}

