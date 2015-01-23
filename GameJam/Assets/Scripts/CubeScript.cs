using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	enum Type {
		melee,
		ranged,
		tank
	}

	enum Element {
		fire,
		water,
		earth,
		electricity
	}

	int health;
	Type type;
	Element element;

	// Use this for initialization
	void Start() {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
