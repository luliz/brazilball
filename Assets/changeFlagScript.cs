using UnityEngine;
using System.Collections;

public class changeFlagScript : MonoBehaviour {

	void OnTriggerStay2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			if (Input.GetKeyDown(Controls.enterHouse)) {

				this.GetComponent<Animator> ().SetTrigger ("change");
			}
		}
	}
}
