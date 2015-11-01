using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

	public Sprite[] nuvens;
	SpriteRenderer spriteRenderer;
	float speed;
	void Awake () {

		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	// Use this for initialization
	void Start () {

		int randomNumber = Random.Range (1, 9);

		spriteRenderer.sprite = nuvens [randomNumber - 1];

		speed = Random.Range (0.1f, 0.5f);
	}
	
	void Update () {

		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
}
