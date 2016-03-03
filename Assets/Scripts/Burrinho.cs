using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Burrinho : MonoBehaviour {

	bool arrived = false;
	public float speed = 5f;
	public float health;
	public GameManager gameManager;
	public Image filledHPImage;
	float finalCounter = 0;

	void Update () {
		if (arrived) {

			finalCounter += Time.deltaTime;
		}

		if (finalCounter >= 3f) {

			Application.LoadLevel(0);
		}
		if (!arrived)
			transform.Translate (Vector3.right * speed * Time.deltaTime);

		filledHPImage.rectTransform.sizeDelta = new Vector2 (health, filledHPImage.rectTransform.rect.size.y);
		filledHPImage.rectTransform.anchoredPosition = new Vector2 (-337f - (100f - health) / 2f, filledHPImage.rectTransform.anchoredPosition.y);

		if (health == 0){

			Destroy (gameObject);
			gameManager.GameOver ();
		}
		if (transform.position.x >= 313f) {
			Destroy (GameObject.Find("MasterRespawn"));
			if (transform.position.x >= 92f) {

				GetComponent<Animator> ().SetTrigger ("chegou");
				arrived = true;
				print ("Tu as gagne");
			}
		}
	}
	void TakeDamage () {

		health -= 20f;
	}
	void OnTriggerEnter2D (Collider2D col) {

		
		if (col.gameObject.name == "Dardo(Clone)") {
			Destroy(col.gameObject);
			TakeDamage();
		}
	}
}
