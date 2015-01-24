using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {
	public float HP = 25f;
	public string Element;
	public string Weapon = "Ranged";

	// Use this for initialization
	void Start () {
		switch(Element) {
			case "Fire":
				renderer.material.color = Color.red;
				break;
			case "Earth":
				renderer.material.color = Color.green;
				break;
			case "Electro":
				renderer.material.color = Color.yellow;
				break;
			case "Water":
				renderer.material.color = Color.blue;
				break;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "ProjectileTeam1") {
			BulletBehaviour vs = col.gameObject.GetComponent<BulletBehaviour>();
			HP -= vs.dmg * getElementWeakness(vs.Element) / getWeaponResist(vs.Weapon);
		 	if (HP <= 0) {
				renderer.material.color = Color.black;
			}
			Destroy(col.gameObject);
		}
	}

	float getElementWeakness(string vsElement) {
		if ((Element == "Fire" && vsElement == "Water") ||
			(Element == "Earth" && vsElement == "Fire") ||
			(Element == "Electro" && vsElement == "Earth") ||
			(Element == "Water" && vsElement == "Electro")) {
			return 2;
		} else {
			return 1;
		}
	}

	float getWeaponResist(string vsWeapon) {
		if ((Weapon == "Melee" && vsWeapon == "Tank") ||
			(Weapon == "Tank" && vsWeapon == "Ranged") ||
			(Weapon == "Ranged" && vsWeapon == "Melee")) {
			return 2;
		} else {
			return 1;
		}
	}
}
