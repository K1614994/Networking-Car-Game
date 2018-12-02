using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class TabFeature : MonoBehaviour {

    public InputField nextFields;
    InputField myField;
	// Use this for initialization
	void Start () {
        if (nextFields == null)
        {
            Destroy(this);
            return;
        }
        myField = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
		if (myField.isFocused && Input.GetKeyDown(KeyCode.Tab))
        {
            nextFields.ActivateInputField();
        }
	}
}
