using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public int lives = 1;

	public void TakeDamage () {

		if (lives == 1) {

			lives = 0;
			this.GetComponent<Animator> ().SetFloat ("lives", 0);

		} else {

			print ("DEAD!!!!!!!!!!!!!!!!!!!!");
		}
	}
}
