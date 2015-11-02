using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeFlagScript : MonoBehaviour {

	public GameObject message;
	GameObject createdMessage;
	bool interactable = true;

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.CompareTag ("Player")) {
			if (!createdMessage && interactable) {
				createdMessage = Instantiate (message);
			}
		}
	}

	void OnTriggerStay2D (Collider2D col) {

		if (col.CompareTag ("Player")) {

			if (Input.GetKeyDown(Controls.enterHouse)) {
				interactable = false;
				if (createdMessage) {
					Destroy (createdMessage);
				}
				this.GetComponent<Animator> ().SetTrigger ("change");
				if (PlayerPrefs.GetInt("highscore") < pontuacao.pontos) {

					PlayerPrefs.SetInt("highscore", pontuacao.pontos);
				}

                Application.LoadLevel(7);
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
