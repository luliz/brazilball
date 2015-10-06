using UnityEngine;
using System.Collections;

public class Galinha : MonoBehaviour {


	private float timeToBegin;

	void Start() {

		timeToBegin = Random.value * 2;
		
	}
	// Update is called once per frame
	void Update () {

		if (timeToBegin <= 0) {

			this.GetComponent<Animator>().SetTrigger("mover");
			timeToBegin = Random.value * 4;
		}
		timeToBegin -= Time.deltaTime;
	}
}
