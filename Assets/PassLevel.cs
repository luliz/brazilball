using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PassLevel : MonoBehaviour {

	public int nextLevel;

	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Return)) {

			SceneManager.LoadScene (nextLevel);
		}
	}
}
