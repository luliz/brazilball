using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.CompareTag ("enemy")) {

			col.gameObject.GetComponent<BasicAI> ().TakeDamage();
		}
	}
}
