using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	
	public bool automatic;
	public Vector3 spawnPosition;
	public int levelToGo;

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
}
