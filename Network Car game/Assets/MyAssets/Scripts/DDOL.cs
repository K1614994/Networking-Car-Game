using UnityEngine;

public class DDOL : MonoBehaviour {

	// Use this for initialization
	private void Awake() {

        DontDestroyOnLoad(this);
        /*if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
            
        }*/
        
	}
	
	
}
