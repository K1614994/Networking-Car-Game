using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{ // create static class called DBManager

    // set up static variables 
    public static string username;
    public static string email;
    public static int carColour;
    public static int score = 0;
    public static int gamesPlayed;
    public static int gamesWon;
    public static int gamesLost;
    public static int tTimeHeld;
    public static int hTimeHeld;
    public static int aTimeHeld;


    //set up static bool
    public static bool LoggedIn { get { return username != null; } }



    public static void Logout()
    {
        username = null; // When Logout() is called set the variable username to null; 
    }
}
