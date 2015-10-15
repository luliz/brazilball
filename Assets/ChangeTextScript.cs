using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeTextScript : MonoBehaviour {

	public string type;

	Text text;
	void Awake () {

		text = this.GetComponent<Text> ();
	}
	// Update is called once per frame
	void Update () {

		UpdateText ();
	}

	public void UpdateText () {

		text.text = type;

		switch (type) {
		case "Jump: ":
			text.text += Controls.jump.ToString();
			break;
		case "Attack: ":
			text.text += Controls.strongAttack.ToString();
			break;
		case "Pause: ":
			text.text += Controls.pause.ToString();
			break;
		case "Walk Left: ":
			text.text += Controls.walkLeft.ToString();
			break;
		case "Walk Right: ":
			text.text += Controls.walkRight.ToString();
			break;
		}
	}
}
