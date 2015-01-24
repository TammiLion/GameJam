using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	public enum Type {
		melee,
		ranged,
		tank
	}

	public enum Element {
		fire,
		water,
		earth,
		electricity
	}

	public int health = 3;
	public Type type;
	public Element element;
	public int player;
	public int id;

	// Use this for initialization
	void Start() {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
