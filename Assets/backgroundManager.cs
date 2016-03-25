using UnityEngine;
using System.Collections;

public class backgroundManager : MonoBehaviour {

	public GameObject gameObjectChao;
	public Sprite[] backgroundSprites;

	private Transform chaoParent;

	// Use this for initialization
	void Start () {
	
		chaoParent = GameObject.Find ("chaoParent").transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (chaoParent.childCount <= 2) {

			CreateNewBackground ();
		}
	}

	void CreateNewBackground () {

		int numChildren = chaoParent.childCount;
		Vector2 positionToInstantiate = new Vector2 (chaoParent.GetChild (numChildren - 1).position.x + 22.07f, 0);
		GameObject chaoInstanciado = (GameObject) Instantiate (gameObjectChao, positionToInstantiate, Quaternion.identity);
		chaoInstanciado.transform.SetParent (chaoParent, true);
		chaoInstanciado.GetComponent<SpriteRenderer> ().sprite = backgroundSprites [Random.Range (0, backgroundSprites.Length - 1)];
	}
}
