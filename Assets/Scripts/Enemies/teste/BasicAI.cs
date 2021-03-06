﻿using UnityEngine;
using System.Collections;

public abstract class BasicAI : MonoBehaviour {

	public bool attacking = false;
	//PRIVATE VARIABLES

	public GameObject particles;

	protected PlayerStatus status;
	static public int health ;
	protected float memory;
	public int estado = 0;
	protected RaycastHit2D saw;
	protected float timeAfterISaw;
	protected int facingDirection = 1;
	protected int decision;
	protected float spriteCounter;
	private Collider2D thisCollider;
	private float decisionCounter;
	protected bool canFlip = true;
	protected float raycastOffset;
	protected GameManager gameManager;

    protected float minDistanceToAttack;
    protected float maxDistanceToAttack;
    protected float maxDistanceToFollow;
    protected float maxVerticalDistanceToAttack;


	//PUBLIC VARIABLES
	protected Transform target;
	public Animator animator;
	public Animator weaponAnimator;
	public SpriteRenderer expressions;
	public Sprite interrogation;
	public Sprite exclamation;
	public LayerMask visao;
	public LayerMask barreira;
	protected float speed;

	//Metodos
	public abstract void Follow ();
	public abstract void Attack ();
	public abstract void DoExtraStuff ();
	public abstract void TakeDamage ();

	public int enemyID;
	void Awake() {
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		thisCollider = GetComponentInChildren<Collider2D>();
		status = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStatus> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	void Update() {

		Found ();

		if (estado == 0) {
			Search ();

		} else if (estado == 1) {
			Follow ();

		} else if (estado == 2){
            

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
		if (status.invisible && !saw)
			estado = 0;
		DoExtraStuff ();
		if (canFlip) {
			Flip ();
		}
	}

	protected virtual void Search () {
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
		saw = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - raycastOffset), Vector2.right * facingDirection, 4f, visao);
	
		//if (saw.transform)
		//	print (saw.transform);
		if (saw.transform == target  && !status.invisible)
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

		transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facingDirection, transform.localScale.y, 1);
		//transform.localScale = new Vector3(facingDirection, 1, 1);
		if (expressions)
			expressions.transform.localScale = new Vector3(facingDirection, 1, 1);		
	}
}
