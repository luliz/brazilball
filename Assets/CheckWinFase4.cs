using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckWinFase4 : MonoBehaviour {

	public int nextLevel;

	// Update is called once per frame
	void Update () {
		if (transform.position.x >= 94f) {

			SceneManager.LoadScene (nextLevel);
		}
	}
}
