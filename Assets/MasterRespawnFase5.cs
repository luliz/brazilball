using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MasterRespawnFase5 : MonoBehaviour {

	public int nextLevel;
	public static int enemiesKilled;
	public float tempoEntreRespawns;
	private float timer;
	public int maxEnemies;
	private int enemiesInstantiated;
	public GameObject enemyOnHorse;

	// Use this for initialization
	void Start () {
		timer = tempoEntreRespawns;
	}
	
	// Update is called once per frame
	void Update () {
		print ("Instanciados: "+enemiesInstantiated+"; Mortos: "+enemiesKilled);
		timer -= Time.deltaTime;
		if (timer <= 0f) {
			if (enemiesInstantiated <= maxEnemies) {
				Instantiate (enemyOnHorse, Vector3.zero, Quaternion.identity);
				enemiesInstantiated++;
				if (tempoEntreRespawns > 1)
					tempoEntreRespawns -= 0.2f;
				timer = tempoEntreRespawns;
			} else {

				if (enemiesKilled == enemiesInstantiated) {

					SceneManager.LoadScene (nextLevel);
				}
			}
		}
	}
}
