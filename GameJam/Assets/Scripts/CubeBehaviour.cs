using UnityEngine;
using System.Collections;

public class CubeBehaviour : MonoBehaviour {
	public float HP = 25f;
	public string Element;
	public string Weapon = "Ranged";
	public Transform explosion;
	public Transform stun;

	public int pos;

	public Transform bulletPrefab;

	public float bulletTimer = 0;

	public bool stunned = false;
	private float stunTimer = 0f;

	protected bool dead = false;

	// Use this for initialization
	public void Start () {
		setColor();
	}

	void setColor () {
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
	void FixedUpdate () {
		if (!dead) {
			if (stunTimer <= 0f) {
				stunned = false;
				setColor ();
			} else {
				stunTimer -= Time.deltaTime;
			}
		} else {
			renderer.material.color = Color.black;
		}
	}

	public void GetStunned () {
		Instantiate (stun, transform.position, transform.rotation);

		stunned = true;
		stunTimer = 3f;
	}

	public virtual void Attack() {
		//Empty attack virtual
	}

	public virtual void TakeDamage (CubeBehaviour origin, float dmg) {
		transform.parent.GetComponent<PlayerBehaviour>().HP -= dmg * getElementWeakness(origin.Element) / getWeaponResist(origin.Weapon);

 		Instantiate (explosion, transform.position, transform.rotation);

	}

	public virtual void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "ProjectileTeam1") {
			BulletBehaviour vs = col.gameObject.GetComponent<BulletBehaviour>();

			TakeDamage(vs.origin.GetComponent<CubeBehaviour>(), vs.dmg);
			Destroy(col.gameObject);
		}
	}

	public float getElementWeakness(string vsElement) {
		if ((Element == "Fire" && vsElement == "Water") ||
			(Element == "Earth" && vsElement == "Fire") ||
			(Element == "Electro" && vsElement == "Earth") ||
			(Element == "Water" && vsElement == "Electro")) {
			return 2;
		} else {
			return 1;
		}
	}

	public float getWeaponResist(string vsWeapon) {
		if ((Weapon == "Melee" && vsWeapon == "Tank") ||
			(Weapon == "Tank" && vsWeapon == "Ranged") ||
			(Weapon == "Ranged" && vsWeapon == "Melee")) {
			return 2;
		} else {
			return 1;
		}
	}
}
