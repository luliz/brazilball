using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	PlayerStatus status;

	public GameObject mainMenu;
	public GameObject areYouSure;
	public static GameObject menuCreated = null;
	public static GameObject windowCreated = null;

	void Awake () {

		status = GameObject.Find ("Player").GetComponent<PlayerStatus> ();
	}
	void Update () {
		if (Input.GetKeyDown (Controls.pause) && !status.gameOver) {
			if (menuCreated) {
				DestroyMenu ();
			}
			else {
				CreateMenu ();
			}
		} 
	}
	public void Pause () {
		if (Time.timeScale == 1) {
			GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
			Time.timeScale = 0.0000001f;
		} else {
			GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
			Time.timeScale = 1;
		}
	}
	public void CreateMenu() {
		Pause ();

		menuCreated = Instantiate (mainMenu);
	}

	public void DestroyMenu () {
		Pause ();
		Destroy (menuCreated);
	}

	public void OnClickExitButton () {
		Button[] buttons = menuCreated.GetComponentsInChildren<Button> ();
		for (int i = 0; i < buttons.Length; i++) {

			buttons[i].interactable = false;
		}
		windowCreated = Instantiate (areYouSure);
	}
	public void ExitGame() {

		Application.Quit ();
	}
	public void CancelExitGame () {
		Button[] buttons = menuCreated.GetComponentsInChildren<Button> ();
		for (int i = 0; i < buttons.Length; i++) {
			
			buttons[i].interactable = true;
		}
		Destroy (windowCreated);
	}
}
