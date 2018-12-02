using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{

    public Material Material1;
    public Material Material2;
    public Material Material3;

   
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;

    void Start()
    {
        if (DBManager.carColour == 1)
        {
            Object.GetComponent<MeshRenderer>().material = Material1;
        }
        else if (DBManager.carColour == 2)
        {
            Object.GetComponent<MeshRenderer>().material = Material2;
        }
        else 
        {
            Object.GetComponent<MeshRenderer>().material = Material3;
        }
    }
}