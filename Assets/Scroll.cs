using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scroll : MonoBehaviour {
	int teste = 0;
	public GameObject message;
	GameObject createdMessage;
	public GameObject scroll;
	public string texto;

	void OnTriggerStay2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			print ("teste"+teste);
			teste++;
			if (!createdMessage && message) {
				createdMessage = Instantiate (message);
			}

			if (Input.GetKey(Controls.enterHouse)) {

				GameObject createdScroll = Instantiate (scroll);
				Text text = createdScroll.GetComponentInChildren<Text> ();
				text.text = texto;
				Destroy (gameObject);
				Destroy (createdMessage);
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

