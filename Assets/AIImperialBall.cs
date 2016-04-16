using UnityEngine;
using System.Collections;

public class AIImperialBall : BasicAI {

	private float[] xPositions;
	private float[] timeToWait;

	private float timeToAwake;

	private int currentTargetPosition = 0;
	private float waitTime = 0;
	private float freezeTimer=0.5f;
	private bool once = false;

	void Start () {
		Physics2D.IgnoreLayerCollision (2, 2);
		target = GameObject.Find ("Player").transform;
		speed = 1f;
		raycastOffset = 0f;
		xPositions = new float[2];
		xPositions [0] = transform.position.x - 5f;
		xPositions [1] = transform.position.x + 5f;

		timeToWait = new float[2];
		timeToWait [0] = 1.5f;
		timeToWait [1] = 1.5f;
		timeToAwake = Random.value*2;
	}
	protected override void Search () {
		if (Found ()) {

			estado = 1;
			return;
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
		print ("ue");
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

		print (estado);
		timeToAwake -= Time.deltaTime;
		if (timeToAwake > 0) {

			estado = 2;
		} else if (!once) {
			estado = 0;
			once = true;
		}
		if (status.invisible)
			Physics2D.IgnoreCollision (GetComponent<CircleCollider2D> (), target.GetComponent<CircleCollider2D> ());
		else
			Physics2D.IgnoreCollision (GetComponent<CircleCollider2D> (), target.GetComponent<CircleCollider2D> (), false);
	}

	public override void TakeDamage() {
		return;
	}
}
