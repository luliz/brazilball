using UnityEngine;
using System.Collections;

public class eventSystem : MonoBehaviour {

	void Update () {
	
		if (Application.loadedLevel == 6 && Input.GetKeyDown (KeyCode.Return)) {

			Application.LoadLevel(5);
		}

        if (Application.loadedLevelName == "Fase 1.5" && Input.GetKeyDown(KeyCode.Return))
        {

            Application.LoadLevel(8);
        }

        if (Application.loadedLevelName == "Fase 1.5.2" && Input.GetKeyDown(KeyCode.Return))
        {

            Application.LoadLevel(9);
        }
    }
}
