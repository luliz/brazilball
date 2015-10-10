using UnityEngine;
using System.Collections;

public class Archer2 : BasicAI {

	private float contador=0f;
	public Transform arrow;
	public Transform ponta;
	private float min=4f;
	private float contador2;
	public AudioClip soundshoot;

	public override void Follow() {

		if (timeAfterISaw > 3.5)
		{
			estado = 0;
			expressions.sprite = interrogation;
		}
		
		if (Mathf.Abs(target.position.x - transform.position.x) >= 5f && Mathf.Abs(target.position.x - transform.position.x) < 20f)
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
		else if (Mathf.Abs(target.position.x - transform.position.x) < 5f && Mathf.Abs(target.position.x - transform.position.x) > min)
		{
			
			animator.SetBool("walk", false);
			min = 2f;
			if (transform.position.x > target.position.x)
			{
				facingDirection = -1;
				
			}
			else
			{
				
				facingDirection = 1;
				
			}

			if(contador2 > Time.time)
				Attack();
			else
				contador2 = Time.time + 0.1f;


			if (Mathf.Abs(target.position.y - transform.position.y) < 0.5)
				
				estado = 2;                      
		}
		
		else 
		{
			
			Walk();
			min=4f;
			if (transform.position.x > target.position.x)
			{
				facingDirection = 1;
			}
			else
			{
				
				facingDirection = -1;
			}           
		}
	}

	public override void Attack() {

		if (contador <= Time.time) {
			Instantiate(arrow, ponta.transform.position, Quaternion.identity);
			contador = Time.time + 1f;
			contador2 = 0f;
			AudioSource.PlayClipAtPoint(soundshoot, transform.position * 0);
		}
	}
	public override void DoExtraStuff() {

		return;
	}
}
