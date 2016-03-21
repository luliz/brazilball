using UnityEngine;
using System.Collections;

public class MasterRespawnFase5 : MonoBehaviour {

	public float tempoEntreRespawns;
	private float timer;
	public GameObject enemyOnHorse;

	// Use this for initialization
	void Start () {
		timer = tempoEntreRespawns;
	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;
		if (timer <= 0f) {

			Instantiate (enemyOnHorse, Vector3.zero, Quaternion.identity);
			if (tempoEntreRespawns > 1)
				tempoEntreRespawns -= 0.2f;
			timer = tempoEntreRespawns;
		}
	}
}
