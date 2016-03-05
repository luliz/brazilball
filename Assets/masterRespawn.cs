using UnityEngine;
using System.Collections;

public class masterRespawn : MonoBehaviour {

	public Transform playerTransform;
	public Transform burrinho;
	public Transform[] spawnPoints;
	public Transform[] threeClosestSpawnPoints;
	public float respawnCounter = 0f;
	public float timeBetweenRespawns;
	int indiosNaSceneCounter;
	public Transform dummy;

	void Update () {

		respawnCounter += Time.deltaTime;
		if (respawnCounter >= timeBetweenRespawns) {
			for (int i = 0; i < threeClosestSpawnPoints.Length; i++) {

				threeClosestSpawnPoints[i] = dummy;
			}
			if (GameObject.FindGameObjectsWithTag ("enemy").Length < 6) {
				for (int i = 0; i < spawnPoints.Length; i++) {

					for (int j = 0; j < threeClosestSpawnPoints.Length; j++) {

						if (Mathf.Abs (burrinho.transform.position.x - spawnPoints[i].position.x) <= Mathf.Abs (burrinho.transform.position.x - threeClosestSpawnPoints[j].transform.position.x)) {

							threeClosestSpawnPoints[j] = spawnPoints [i];
							break;
						}
					}
				}

				for (int i = 0; i <threeClosestSpawnPoints.Length; i++) {

					if (Mathf.Abs (threeClosestSpawnPoints[i].transform.position.x - playerTransform.position.x) > 6f) {
						threeClosestSpawnPoints[i].GetComponent<respawnPoint> ().Respawn ();
					}
				}
				respawnCounter = 0f;
			}
		}
	}
}
