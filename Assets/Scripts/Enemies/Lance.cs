using UnityEngine;
using System.Collections;

public class Lance : MonoBehaviour {

	public Transform parentTransform;
	int parentFacingDirection;
	void Update () {

		parentFacingDirection = (int) parentTransform.localScale.x;
	}
	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag == "Player") {
			col.GetComponent<PlayerStatus>().TakeDamage(parentFacingDirection);
		}
	}
}
