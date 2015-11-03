using UnityEngine;
using System.Collections;

public class Capacete : MonoBehaviour {

	public int hatID;

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Player") {

			GameManager.hatsPicked.Add (hatID);
			PlayerStatus.lives = 1;
			Destroy (gameObject);
		}
	}
}
