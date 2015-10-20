using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	private EdgeCollider2D thisCollider;

	void Awake () {

		thisCollider = GetComponentInParent<EdgeCollider2D> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			Physics2D.IgnoreCollision (col, thisCollider, true);
		}
	}

	void OnTriggerExit2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			Physics2D.IgnoreCollision(col, thisCollider, false);
		}
	}
}
