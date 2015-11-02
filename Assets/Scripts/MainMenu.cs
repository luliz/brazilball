using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Application.LoadLevel(6);
    }
}
