using UnityEngine;
using System.Collections;

public class Boss : BasicAI {

	public GameObject[] pontosF;
	public float areaBossSize;
	public float areaBossCenter;
	float callArrowsCounter = 0;
	public float timeBetweenCalls = 6f;

	void Start () {

		speed = 2f;
		health = 2;
		memory = 100f;
		minDistanceToAttack = 0f;
		maxDistanceToAttack = 3f;
		maxDistanceToFollow = 20f;
		raycastOffset = 0f;
		maxVerticalDistanceToAttack = 1.5f;
		target = GameObject.Find("Player").transform;
	}

	protected override void Search () {

		if (Mathf.Abs (target.position.x - areaBossCenter) <= areaBossSize) {

			estado = 1;
			timeAfterISaw = 0;
		}
	}
	public override void Attack ()
	{
		if (!attacking) {
			animator.SetInteger ("status", 1);
			attacking = true;
		}
	}

	public override void DoExtraStuff ()
	{

		callArrowsCounter += Time.deltaTime;
		if (callArrowsCounter >= timeBetweenCalls) {

			estado = 3;
			animator.SetBool ("walk", false);
		}

		if (estado == 3) {

			CallArrows ();
		}
	}

	public void CallArrows () {


		if (callArrowsCounter >= timeBetweenCalls + 4f) {
			
			for (int i = 0; i < pontosF.Length; i++) {

				pontosF[i].GetComponent<PontoF> ().Arrows ();
			}
			estado = 1;
			callArrowsCounter = 0;
		}
	}
	public override void Follow ()
	{
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
			
			if (Mathf.Abs(target.position.y - transform.position.y) < maxVerticalDistanceToAttack)
			{
				estado = 2;
			}
		}
	}

	public override void TakeDamage ()
	{
		if (estado == 3) {

				if (health > 0) {

					health--;
				}
				else {
					
					pontuacao.pontos += 100;
					Destroy(this.gameObject);
				}
		}
	}
}
