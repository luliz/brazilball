using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fase6Controller : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("GameManager").GetComponent<GameManager> ().index == 15) {

			SceneManager.LoadScene ("Menu");
		}
	}
}
