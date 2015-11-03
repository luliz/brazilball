using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.CompareTag ("enemy")) {

			col.gameObject.GetComponent<BasicAI> ().TakeDamage();
		}
		if (col.gameObject.CompareTag ("enemyArcher")) {

			col.gameObject.GetComponent<Archer2> ().TakeDamage();
		}
	}
}
