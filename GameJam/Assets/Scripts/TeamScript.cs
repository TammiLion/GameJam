using UnityEngine;
using System.Collections;

public class TeamScript : MonoBehaviour {

	private Transform bottomCube; //1
	private Transform topCube; //4
	private Transform onBottomCube; //2
	private Transform belowTopCube; //3

	// Use this for initialization
	void Start () {
		getAllCubes ();
	}
	
	void getAllCubes() {
		bottomCube = transform.Find ("bottom");
		topCube = transform.Find("top");
		onBottomCube = transform.Find ("two");
		belowTopCube = transform.Find("three");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
