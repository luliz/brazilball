using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tirinhaController : MonoBehaviour {

	public Sprite[] sprites;
	public int proximaFase;
	private int currentSprite;
	public Image image;

	// Use this for initialization
	void Start () {

		currentSprite = 0;
		image.sprite = sprites [0];
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.anyKeyDown) {

			currentSprite++;
			if (currentSprite == sprites.Length)
				SceneManager.LoadScene (proximaFase);
			else
				image.sprite = sprites [currentSprite];
		}
	}
}
