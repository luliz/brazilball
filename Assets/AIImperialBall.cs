﻿using UnityEngine;
using System.Collections;

public class AIImperialBall : BasicAI {

	public float[] xPositions;
	public float[] timeToWait;

	private int currentTargetPosition = 0;
	private float waitTime = 0;
	private float freezeTimer=0.5f;

	void Start () {
		target = GameObject.Find ("Player").transform;
		speed = 1f;
		raycastOffset = 0f;
	}
	protected override void Search () {
		if (Found ()) {

			estado = 1;
		}
		if (Mathf.Abs(transform.position.x - xPositions [currentTargetPosition]) < 0.5f) {

			if (currentTargetPosition == 0) {
				currentTargetPosition = 1;
			} else if (currentTargetPosition == xPositions.Length - 1) {
				currentTargetPosition = xPositions.Length - 2;
			}
			else {
				currentTargetPosition += facingDirection;
			}

			waitTime = timeToWait [currentTargetPosition];
		} else if (transform.position.x > xPositions [currentTargetPosition]) {

			facingDirection = -1;
		} else {

			facingDirection = 1;
		}

		if (waitTime <= 0) {
			Walk ();
		} else {
			waitTime -= Time.deltaTime;
		}
	}

	public override void Follow () {
		target.GetComponent<PlayerController> ().enabled = false;
		freezeTimer -= Time.deltaTime;
		if (freezeTimer <= 0) {
			gameManager.GameOver ();
			Destroy (gameObject);
		}
	}
	public override void Attack () {
		return;
	}

	public override void DoExtraStuff () {
		if (status.invisible)
			Physics2D.IgnoreCollision (GetComponent<CircleCollider2D> (), target.GetComponent<CircleCollider2D> ());
		else
			Physics2D.IgnoreCollision (GetComponent<CircleCollider2D> (), target.GetComponent<CircleCollider2D> (), false);
	}

	public override void TakeDamage() {
		return;
	}
}
