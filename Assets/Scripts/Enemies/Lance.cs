using UnityEngine;
using System.Collections;

public class Lance : MonoBehaviour {

	public Transform parentTransform;
	int parentFacingDirection;

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag == "Player") {
			parentFacingDirection = (int) parentTransform.localScale.x;
			col.GetComponent<PlayerStatus>().TakeDamage(parentFacingDirection);
		}
	}
}
