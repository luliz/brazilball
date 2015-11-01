using UnityEngine;
using System.Collections;

public class CheckGround : MonoBehaviour {

	PlayerController playerController;
	Animator playerAnimator;

	void Awake () {

		playerController = GameObject.Find ("Player").GetComponent<PlayerController>();
		playerAnimator = GameObject.Find ("Player").GetComponent<Animator> ();
	}
	void OnTriggerStay2D (Collider2D col){
		if(col.gameObject.tag == "Jumpable" || col.gameObject.tag == "enemyArcher")
        {
			playerController.grounded = true;
			playerAnimator.SetBool("ground", true);
		}
	}
	void OnTriggerExit2D (Collider2D col){
		if (col.gameObject.tag == "Jumpable" || col.gameObject.tag == "enemyArcher") {
			playerController.grounded = false;
			playerAnimator.SetBool("ground", false);
		}
	}
}
