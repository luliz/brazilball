using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {


	void OnCollisionEnter2D (Collision2D col) {

		print (col.transform);
		if (col.gameObject.CompareTag ("enemy")) {

			col.gameObject.GetComponent<BasicAI> ().TakeDamage();
		}
	}
}
