using UnityEngine;
using System.Collections;

public class waveInfoScript : MonoBehaviour {

	float theFinalCountdown = 2;
	
	// Update is called once per frame
	void Update () {

		theFinalCountdown -= Time.deltaTime;
		if (theFinalCountdown <= 0f) {
			Destroy (this.gameObject);
		}
	}
}
