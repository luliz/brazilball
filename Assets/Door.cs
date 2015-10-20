using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public int levelToGo;
	void OnTriggerStay2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			if (Input.GetKeyDown(KeyCode.W)) {
				Application.LoadLevel (levelToGo);
			}
		}
	}
}
