using UnityEngine;
using System.Collections;

public class espeto : MonoBehaviour {

	GameManager gameManager;

	void Awake () {

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	void OnTriggerEnter2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			gameManager.GameOver();
		}
	}
}
