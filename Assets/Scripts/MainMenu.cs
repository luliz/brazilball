using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
        Debug.Log("adsa");
    }
    public void StartGame()
    {
        Application.LoadLevel(0);
        Debug.Log("adsa");
    }
}
