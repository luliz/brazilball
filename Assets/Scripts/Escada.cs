using UnityEngine;
using System.Collections;

public class Escada : MonoBehaviour {
	
	PlayerController playerController;

	public float ladderXPosition;
	void Awake () {

		playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void OnTriggerStay2D (Collider2D col) {
	
		if (col.CompareTag ("Player")) {
			playerController.lockedXPosition = ladderXPosition;
			playerController.touchingLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			playerController.touchingLadder = false;
		}
	}
}
