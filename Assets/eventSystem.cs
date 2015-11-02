using UnityEngine;
using System.Collections;

public class eventSystem : MonoBehaviour {

	void Update () {
	
		if (Application.loadedLevel == 6 && Input.GetKeyDown (KeyCode.Return)) {

			Application.LoadLevel(0);
		}

        if (Application.loadedLevel == 7 && Input.GetKeyDown(KeyCode.Return))
        {

            Application.LoadLevel(8);
        }
    }
}
