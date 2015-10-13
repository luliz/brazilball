using UnityEngine;
using System.Collections;

public class Charger : BasicAI {

	public int health = 5;

	private float memory = 3.5f;
	private float minDistanceToAttack = 0f;
	private float maxDistanceToAttack = 2f;
	private float maxDistanceToFollow = 10f;
	private float maxVerticalDistanceToAttack = 0.5f;
	private float attackCounter;
	private float timeToAttack = 0.3f;
	public float chargePower = 10;
	public BoxCollider2D spearCollider;
	private float counter;
	private bool attacked = false;

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
				this.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * facingDirection * chargePower, ForceMode2D.Impulse);
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
			Destroy(this.gameObject);
		}
	}
}
