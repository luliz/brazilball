using UnityEngine;
using System.Collections;

public class MaceAI : BasicAI {

	public AudioSource audioSource;

	void Start () {
		speed = 2f;
		health = 3;
		memory = 10f;
		minDistanceToAttack = 0f;
		maxDistanceToAttack = 1f;
		maxDistanceToFollow = 20f;
		raycastOffset = 0f;
		maxVerticalDistanceToAttack = 1f;
        target = GameObject.Find("Player").transform;
    }
	public override void Follow () {

		if (timeAfterISaw > memory)
		{
			estado = 0;
			if (expressions)
				expressions.sprite = interrogation;
		}
		
		if (Mathf.Abs(target.position.x - transform.position.x) >= maxDistanceToAttack && Mathf.Abs(target.position.x - transform.position.x) < maxDistanceToFollow)
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
				estado = 2;
			}
		}
	}
	
	public override void Attack () {
		if (!attacking) {
			weaponAnimator.SetTrigger ("attacking");
			attacking = true;
		}
	}

	public override void TakeDamage () {

		audioSource.Play ();
		if (health > 0) {

			health--;
		} else {
			
			GameManager.enemiesKilled.Add(this.enemyID);
			Destroy(this.gameObject);
		}
	}

	public override void DoExtraStuff () {
		return;
	}
}
