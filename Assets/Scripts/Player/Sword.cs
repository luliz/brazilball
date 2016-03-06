using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
    


	void OnTriggerEnter2D (Collider2D col) {

		if (col.gameObject.CompareTag ("enemy")) {

			if (col.gameObject.GetComponent<AIzarabatana>()) {
            	col.gameObject.GetComponent<AIzarabatana>().Take();
			}
			if (col.gameObject.GetComponent<BasicAI> ()) {
				col.gameObject.GetComponent<BasicAI> ().TakeDamage();
			}
            

		}
		if (col.gameObject.CompareTag ("enemyArcher")) {

			col.gameObject.GetComponent<Archer2> ().TakeDamage();
		}
	}
}
