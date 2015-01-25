using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public float dmg = 10f;
	public Transform origin;
	public string Weapon = "Ranged";
	public string Element;
	public int dir = 1;


	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce(new Vector2(dir * 500f, 0f));
	}

	// Update is called once per frame
	void Update () {

	}
}
