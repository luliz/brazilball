using UnityEngine;
using System.Collections;

public class BigScroll : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.E)) {
			Destroy (gameObject);
		}
	}
}
