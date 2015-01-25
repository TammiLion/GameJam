using UnityEngine;
using System.Collections;

public class splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("GoToMain", 3.0f);
	}
	
	// Update is called once per frame
	void GoToMain () {
		Application.LoadLevel("MainMenu");
	}
}
