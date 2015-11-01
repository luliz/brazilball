using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updateText : MonoBehaviour {

	Text text;
	Transform player;
	Vector3 playerScreenPosition;

	void Awake () {
		player = GameObject.Find ("Player").transform;
		text = this.GetComponent<Text> ();
	}
	void Update () {
		
		playerScreenPosition = Camera.main.WorldToScreenPoint (player.position);
		text.rectTransform.position = new Vector2 (playerScreenPosition.x, playerScreenPosition.y + 20f);
	}
}
