using UnityEngine;
using System.Collections;

public class Arbusto : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col) {

		if (col.tag == "Player") {

			PlayerStatus status = col.gameObject.GetComponent <PlayerStatus> ();

			status.TurnInvisibilityOn();
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		
		if (col.tag == "Player") {
			
			PlayerStatus status = col.gameObject.GetComponent <PlayerStatus> ();
			
			status.TurnInvisibilityOff();
		}
	}
}
