using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public int lives = 1;
	public float maxImmuneTime = 2f;
	public float counter;

	void Update () {
		counter += Time.deltaTime;
	}
	public void TakeDamage (int direction) {

		if (counter > maxImmuneTime) {
			counter = 0;
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2 (direction * 10, 0), ForceMode2D.Impulse);
			if (lives == 1) {
				lives = 0;
				this.GetComponent<Animator> ().SetFloat ("lives", 0);

			} else {

				print ("DEAD!!!!!!!!!!!!!!!!!!!!");
			}
		}
	}
}
