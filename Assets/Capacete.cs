using UnityEngine;
using System.Collections;

public class Capacete : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Player") {

			PlayerStatus.lives = 1;
			Destroy (gameObject);
		}
	}
}
