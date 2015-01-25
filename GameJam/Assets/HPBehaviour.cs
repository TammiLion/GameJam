using UnityEngine;
using System.Collections;

public class HPBehaviour : MonoBehaviour {
	private float maxHP = 100f;
	private float maxW = 5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetHP (float HP) {
		transform.localScale = new Vector3((HP / 100f) * maxW, 0.5f, 1f);
	}
}
