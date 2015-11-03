using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	private EdgeCollider2D[] thisCollider;

	void Awake () {

		thisCollider = GetComponentsInParent<EdgeCollider2D> ();
	}
	
	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {
			for (int i = 0; i < thisCollider.Length; i++) {
				Physics2D.IgnoreCollision (col, thisCollider[i], true);
			}
		}
	}

	void OnTriggerExit2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			for (int i = 0; i < thisCollider.Length; i++) {
				Physics2D.IgnoreCollision (col, thisCollider[i], false);
			}
		}
	}
}
