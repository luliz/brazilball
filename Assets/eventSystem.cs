using UnityEngine;
using System.Collections;

public class eventSystem : MonoBehaviour {

	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Return)) {

			Application.LoadLevel(0);
		}
	}
}
