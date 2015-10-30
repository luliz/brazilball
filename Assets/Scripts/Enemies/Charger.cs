using UnityEngine;
using System.Collections;

public class Charger : BasicAI {

	private float attackCounter;
	private float timeToAttack = 0.3f;
	public float chargePower = 10;
	public BoxCollider2D spearCollider;
	private float counter;
	private bool attacked = false;

	void Start () {
		speed = 2f;
		health = 1;
		memory = 3.5f;
		minDistanceToAttack = 0f;
		maxDistanceToAttack = 2f;
		maxDistanceToFollow = 40f;
		raycastOffset = 0.5f;
		maxVerticalDistanceToAttack = 0.5f;
	}
	// Update is called once per frame
	public override void Follow () {
		
		if (timeAfterISaw > memory)
		{
			estado = 0;
			if (expressions)
				expressions.sprite = interrogation;
		}
		
		if (Mathf.Abs(target.position.x - transform.position.x) > maxDistanceToAttack && Mathf.Abs(target.position.x - transform.position.x) < maxDistanceToFollow)
		{
			Walk();
			
			if (transform.position.x > target.position.x)
			{
				facingDirection = -1;
			}
			else
			{
				facingDirection = 1;
			}
		}       
		else if (Mathf.Abs(target.position.x - transform.position.x) < maxDistanceToAttack && Mathf.Abs(target.position.x - transform.position.x) > minDistanceToAttack)
		{
			
			animator.SetBool("walk", false);
			if (transform.position.x > target.position.x)
			{
				facingDirection = -1;
				
			}
			else
			{
				
				facingDirection = 1;
				
			}
			
			if (Mathf.Abs(target.position.y - transform.position.y) < maxVerticalDistanceToAttack) {

				if (counter >= 1.5) {
					animator.SetInteger ("status", 1);
					attackCounter = 0;
					estado = 2;
					canFlip = false;
				}

			}
		}
	}

	public override void Attack () {

		attackCounter += Time.deltaTime;
		if (attackCounter >= timeToAttack) {
			if (!attacked) {
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * transform.localScale.x * chargePower, ForceMode2D.Impulse);
				animator.SetInteger ("status", 2);
				spearCollider.enabled = true;
				attacked = true;
			}
			else {

				if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) <= 4) {

					spearCollider.enabled = false;
					canFlip = true;
					attacked = false;
					animator.SetInteger ("status", 0);
					estado = 1;
					counter = 0;
				}
			}
		}
	}

	public override void DoExtraStuff () {
		counter += Time.deltaTime;
	}

	public override void TakeDamage() {

		if (health > 0) {
			health--;
		} else {
			GameManager.enemiesKilled.Add(this.enemyID);
			Destroy(this.gameObject);
		}
	}
}
