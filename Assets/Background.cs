using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float velocidade;
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector2.left * velocidade * Time.deltaTime);
		if (transform.position.x <= -30) {

			Destroy (gameObject);
		}
	}
}
