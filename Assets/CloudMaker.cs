using UnityEngine;
using System.Collections;

public class CloudMaker : MonoBehaviour {

	public GameObject cloud;
	float counter = 0;
	Transform player;

	void Awake () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector2 (player.position.x + 10f, 0);

		if (counter <= 0) {
			Vector3 positionToBeInstantiated = new Vector3 (transform.position.x, Random.Range (-0.35f, 1.5f));
			Instantiate (cloud, positionToBeInstantiated, Quaternion.identity);
			counter = Random.Range (1f, 2f);
		}
		counter -= Time.deltaTime;

	}
}
