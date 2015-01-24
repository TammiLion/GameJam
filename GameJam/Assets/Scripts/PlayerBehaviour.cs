using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour {
	public Transform bulletPrefab;

	private float bulletTimer1 = 0;
	private float bulletTimer2 = 0;
	private float bulletTimer3 = 0;
	private float bulletTimer4 = 0;

	private List<Transform> cubes = new List<Transform>();

	// Use this for initialization
	void Start () {
		int i = 0;
		foreach (Transform child in transform)
		{
			cubes.Add(child);
			i++;
		}
	}

	// Update is called once per frame
	void Update () {
		//move left and right
		float xmove = Input.GetAxis("Horizontal_P1");
		rigidbody2D.AddForce(new Vector2(xmove * 80f, 0));

		//fire1
		if (Input.GetButton("Fire1_P1") && bulletTimer1 >= 1) {
			if (cubes[0].GetComponent<CubeBehaviour>().HP > 0){
				Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, cubes[0].position.y, 0f), Quaternion.identity) as Transform;
				BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
				bul.origin = transform;
				bul.Element = cubes[0].GetComponent<CubeBehaviour>().Element;
			}
			bulletTimer1 = 0;
		}

		//fire2
		if (Input.GetButton("Fire2_P1") && bulletTimer2 >= 1) {
			if (cubes[1].GetComponent<CubeBehaviour>().HP > 0){
				Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, cubes[1].position.y, 0f), Quaternion.identity) as Transform;
				BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
				bul.origin = transform;
				bul.Element = cubes[1].GetComponent<CubeBehaviour>().Element;
			}
			bulletTimer2 = 0;
		}

		//fire1
		if (Input.GetButton("Fire1_P2") && bulletTimer3 >= 1) {
			if (cubes[2].GetComponent<CubeBehaviour>().HP > 0){
				Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, cubes[2].position.y, 0f), Quaternion.identity) as Transform;
				BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
				bul.origin = transform;
				bul.Element = cubes[2].GetComponent<CubeBehaviour>().Element;
			}
			bulletTimer3 = 0;
		}

		//fire2
		if (Input.GetButton("Fire2_P2") && bulletTimer4 >= 1) {
			if (cubes[3].GetComponent<CubeBehaviour>().HP > 0){
				Transform bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + 1f, cubes[3].position.y, 0f), Quaternion.identity) as Transform;
				BulletBehaviour bul = bullet.GetComponent<BulletBehaviour>();
				bul.origin = transform;
				bul.Element = cubes[3].GetComponent<CubeBehaviour>().Element;
			}
			bulletTimer4 = 0;
		}

		bulletTimer1 += Time.deltaTime;
		bulletTimer2 += Time.deltaTime;
		bulletTimer3 += Time.deltaTime;
		bulletTimer4 += Time.deltaTime;
	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag == "Ground"){
			if (Input.GetButton("Jump_P1")) {
				rigidbody2D.AddForce(new Vector2(0, 100f));
			}
		}
	}
}
