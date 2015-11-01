﻿using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public AudioSource audioSource;

	public int lives = 1;
	public float maxImmuneTime = 2f;
	public float counter;
	private bool blink;	
	public Color blinkColor;
	private SpriteRenderer spriteRenderer;
	private float timeBetweenBlinks = 0.5f;
	GameManager gameManager;

	void Awake () {

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}
	void Update () {
		counter += Time.deltaTime;
		if (blink) {
			if (Mathf.Round (counter * 100f) / 100f % timeBetweenBlinks < 0.1) {

				spriteRenderer.color = blinkColor;
			}
			else {

				spriteRenderer.color = Color.white;
			}
			if (counter > maxImmuneTime) {

				spriteRenderer.color = Color.white;
				blink = false;
			}
			
		}
		
	}
	public void TakeDamage (int direction) {

		if (counter > maxImmuneTime) {
			audioSource.Play();
			blink = true;
			counter = 0;
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2 (direction * 10, 0), ForceMode2D.Impulse);
			if (lives == 1) {
				lives = 0;
				this.GetComponent<Animator> ().SetFloat ("lives", 0);

			} else {
				gameManager.GameOver();
			}
		}
	}

}
