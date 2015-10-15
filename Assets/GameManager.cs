using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	PlayerStatus status;

	public GameObject mainMenu;
	public GameObject areYouSure;
	public GameObject changeKeyGUI;
	public GameObject pressKeyNowGUI;

	public static GameObject pressKeyNowCreated = null;
	public static GameObject menuCreated = null;
	public static GameObject windowCreated = null;

	private static bool allowed = true;
	static bool changeKey;
	static string key;

	int next = 0;
	void Awake () {
		status = GameObject.Find ("Player").GetComponent<PlayerStatus> ();
	}

	void OnGUI () {

		if (changeKey) {

			Event e = Event.current;
			if (next > 0) {
				next++;
				if (next > 10) {
					changeKey = false;
					next = 0;
					Button[] buttons = windowCreated.GetComponentsInChildren<Button> ();
					for (int i = 0; i < buttons.Length; i++) {
					
						buttons[i].interactable = true;
					}
				}
			}
			else if (e.type.Equals (EventType.KeyDown)) {

				KeyCode k = e.keyCode;
				switch (key) {
				case "jump":
					Controls.jump = k;
					break;
				case "attack":
					Controls.strongAttack = k;
					break;
				case "pause":
					Controls.pause = k;
					break;
				case "walkLeft":
					Controls.walkLeft = k;
					break;
				case "walkRight":
					Controls.walkRight = k;
					break;
				}
				Destroy (pressKeyNowCreated);
				next = 1;
			}
		}
	}
	void Update () {
		print (allowed);
		if (Input.GetKeyDown (Controls.pause) && !status.gameOver && allowed) {
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

	public void ChangeKey (string keyToChange) {
		Button[] buttons = windowCreated.GetComponentsInChildren<Button> ();
		for (int i = 0; i < buttons.Length; i++) {
			
			buttons[i].interactable = false;
		}
		pressKeyNowCreated = Instantiate (pressKeyNowGUI);
		key = keyToChange;
		changeKey = true;

	}

	public void OpenChangeKeysMenu () {
		allowed = false;
		print ("shit");
		Destroy (menuCreated);
		windowCreated = Instantiate (changeKeyGUI);
	}

	public void ReturnToMenu () {
		allowed = true;
		Destroy (windowCreated);
		menuCreated = Instantiate (mainMenu);
	}
}
