using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Burrinho : MonoBehaviour {

	public float speed = 5f;
	public float health;

	public Image filledHPImage;

	void Update () {

		transform.Translate (Vector3.right * speed * Time.deltaTime);

		filledHPImage.rectTransform.sizeDelta = new Vector2 (health, filledHPImage.rectTransform.rect.size.y);
		filledHPImage.rectTransform.anchoredPosition = new Vector2 (-505f - (100f - health) / 2f, filledHPImage.rectTransform.anchoredPosition.y);
		if (Input.GetKeyDown (KeyCode.Return)) {

			health -= 10f;
		}
		else if (health == 0){

			Destroy (gameObject);
		}
	}
}
