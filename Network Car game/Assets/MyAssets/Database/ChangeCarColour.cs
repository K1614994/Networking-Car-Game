using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCarColour : MonoBehaviour {

    public void carRed()
    {
        DBManager.carColour = 1;
        CallColour();
    }

    public void carBlue()
    {
        DBManager.carColour = 2;
        CallColour();
    }

    public void carGreen()
    {
        DBManager.carColour = 3;
        CallColour();
    }



    public void CallColour()
    {
        StartCoroutine(ChangeCar()); // when called start the coroutine
    }

    IEnumerator ChangeCar()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username); // set the form to the DBManager variable
        form.AddField("carC", DBManager.carColour); // set the form to the DBManager variable
        WWW www = new WWW("https://kunet.kingston.ac.uk/k1609271/MultiplayerGame/UnityFiles/changeCar.php", form); // assign the web adress to the www type WWW
        yield return www;

    } // deletes the users account
}
