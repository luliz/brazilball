using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public GameObject message;
	GameObject createdMessage;
	public bool automatic;
	public Vector3 spawnPosition;
	public int levelToGo;

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.CompareTag ("Player")) {
			if (!createdMessage) {
				createdMessage = Instantiate (message);
			}
		}
	}
	void OnTriggerStay2D (Collider2D col) {

		if (col.CompareTag ("Player")) {
			if (automatic) {

				Application.LoadLevel (levelToGo);
				PlayerController.playerSpawnPosition = spawnPosition;
			}
			else {
				if (Input.GetKeyDown(Controls.enterHouse)) {

					Application.LoadLevel (levelToGo);
					PlayerController.playerSpawnPosition = spawnPosition;
				}
			}
		}
	}
	void OnTriggerExit2D (Collider2D col) {
		
		if (col.CompareTag ("Player")) {
			if (createdMessage) {
				Destroy (createdMessage);
			}
		}
	}
}
