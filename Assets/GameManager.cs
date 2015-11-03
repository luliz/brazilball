using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	PlayerStatus status;
	public static List<int> enemiesKilled = new List<int>();
	public static List<int> coinsPicked = new List<int> ();
	public static int faseAtual;
    public int index;

	public GameObject mainMenu;
	public GameObject areYouSure;
	public GameObject changeKeyGUI;
	public GameObject pressKeyNowGUI;
	public GameObject gameOverScreen;

	public static GameObject pressKeyNowCreated = null;
	public static GameObject menuCreated = null;
	public static GameObject windowCreated = null;

	private static bool allowed = true;
	static bool changeKey;
	static string key;
	bool gameOver = false;

	int next = 0;
	void Awake () {

		status = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStatus> ();
	}

	void Start () {
		if (faseAtual == 0) {

			faseAtual = 5;
		}
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		
		for (int i = 0; i < GameManager.enemiesKilled.ToArray ().Length; i++) {

			for (int j = 0; j < enemies.Length; j++) {
				if (GameManager.enemiesKilled[i] == enemies[j].GetComponent<BasicAI> ().enemyID) {
					Destroy (enemies[j]);
				}
			}
		}

		GameObject[] coins = GameObject.FindGameObjectsWithTag ("coin");
		
		for (int i = 0; i < GameManager.coinsPicked.ToArray ().Length; i++) {
			
			for (int j = 0; j < coins.Length; j++) {
				if (GameManager.coinsPicked[i] == coins[j].GetComponent<moedas> ().coinID) {
					Destroy (coins[j]);
				}
			}
		}
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
		if (gameOver) {
			
			if (Input.GetKeyDown (KeyCode.Return)) {

				PlayerController.playerSpawnPosition = new Vector3 (-34f, -4f);
				Application.LoadLevel(faseAtual);

				Pause ();
			}
		}

		if (Input.GetKeyDown (Controls.pause) && !gameOver && allowed) {
			if (menuCreated) {
				DestroyMenu ();
			}
			else {
				CreateMenu ();
			}
		}

        index = GameManager.enemiesKilled.ToArray().Length;
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

	public void GameOver () {

		enemiesKilled.Clear ();
		coinsPicked.Clear ();
		pontuacao.moedas = 0;
		pontuacao.pontos = 0;
		PlayerStatus.lives = 1;
		Pause ();
		Instantiate (gameOverScreen);
		gameOver = true;
	}
}
