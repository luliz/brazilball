using UnityEngine;
using System.Collections;

public abstract class BasicAI : MonoBehaviour {

	//PRIVATE VARIABLES
	protected int estado = 0;
	protected RaycastHit2D saw;
	protected float timeAfterISaw;
	protected int facingDirection = 1;
	protected int decision;
	protected float spriteCounter;
	private Collider2D thisCollider;
	private float decisionCounter;
	protected bool canFlip = true;


	//PUBLIC VARIABLES
	public Transform target;
	public Animator animator;
	public SpriteRenderer expressions;
	public Sprite interrogation;
	public Sprite exclamation;
	public LayerMask visao;
	public LayerMask barreira;
	public float speed;

	//Metodos
	public abstract void Follow ();
	public abstract void Attack ();
	public abstract void DoExtraStuff ();
	public abstract void TakeDamage ();
	void Awake() {
		thisCollider = GetComponentInChildren<Collider2D>();
	}
	void Update() {

		Found ();

		if (estado == 0) {

			Search ();

		} else if (estado == 1) {

			Follow ();

		} else {

			Attack ();

		}

		timeAfterISaw += Time.deltaTime;

		if (expressions) {

			if (expressions.sprite != null) {
				spriteCounter += Time.deltaTime;
				if (spriteCounter > 0.7) {
					spriteCounter = 0;
					expressions.sprite = null;
				}
			}
		}

		DoExtraStuff ();
		if (canFlip) {
			Flip ();
		}
	}

	protected void Search () {
		if (Found ()) {
			estado = 1;
		}
		if (decision == 1)
		{
			facingDirection = -1;

			Walk();
		}
		else if (decision == 2)
		{
			facingDirection = 1;
			Walk();
		}
		else
		{	
			if (animator)
				animator.SetBool("walk", false);
		}
		
		decisionCounter += Time.deltaTime;
		
		if (decisionCounter > 1)
		{
			decision = (int)Random.Range(1, 4);
			decisionCounter = 0;
		}
	}

	protected void Walk()
	{

		if (thisCollider.IsTouchingLayers (barreira)) {
			if (animator)
				animator.SetBool ("walk", false);
		}
		else
		{
			if (animator)
				animator.SetBool("walk", true);
			transform.Translate(new Vector2(speed * facingDirection * Time.deltaTime, 0));
		}
	}

	protected bool Found()
	{
		saw = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.5f), Vector2.right * facingDirection, 10f, visao);
		if (saw.transform == target)
		{
			
			timeAfterISaw = 0;
			if (expressions) {
				if (estado == 0)
					expressions.sprite = exclamation;
			}
			return true;
		}
		return false;
	}

	protected void Flip()
	{

		transform.localScale = new Vector3(facingDirection, 1, 1);
		if (expressions)
			expressions.transform.localScale = new Vector3(facingDirection, 1, 1);
		
	}
}
