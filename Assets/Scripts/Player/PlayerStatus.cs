using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

	public AudioSource audioSource;

	public static int lives;
	static bool gameBegins = false;
	public float maxImmuneTime = 2f;
	private float counter = 2f;
	private bool blink;	
	public Color blinkColor;
	public Color invisibilityColor;
	public bool invisible = false;
	private SpriteRenderer spriteRenderer;
	private float timeBetweenBlinks = 0.5f;
	GameManager gameManager;

	void Awake () {

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		spriteRenderer = this.GetComponent<SpriteRenderer> ();
	}

	void Start () {

		if (!gameBegins) {

			gameBegins = true;
			lives = 1;
		}
	}
	void Update () {
		counter += Time.deltaTime;
		if (this.GetComponent<Animator> ())
			this.GetComponent<Animator> ().SetFloat ("lives", lives);
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

	public void TurnInvisibilityOn () {

		spriteRenderer.color = invisibilityColor;
		invisible = true;
	}

	public void TurnInvisibilityOff () {
		
		spriteRenderer.color = Color.white;
		invisible = false;
	}
	public void TakeDamage (int direction) {
		if (counter > maxImmuneTime) {
			audioSource.Play();
			blink = true;
			counter = 0;
            Vidas.capacetes--;
            lives--;
			this.GetComponent<Rigidbody2D>().AddForce(new Vector2 (direction * 3, 0), ForceMode2D.Impulse);
			if (lives < 0) {
                gameManager.GameOver();

			} 
		}
	}

}
