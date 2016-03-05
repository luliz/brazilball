using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fase3spawn : MonoBehaviour {

	//criticalWave eh a wave a partir da qual comecara a spawnar dois inimigos ao mesmo tempo

	public Transform[] respawnPoints;
	public float timeToRespawn;
	private float timeLeftToRespawn;
	public int[] numberOfEnemiesPerWave;
	public Sprite[] spriteWaveInfo;
	public GameObject waveInfo;
	private int currentWave = 0;
	public int criticalWave;
	private int numberOfEnemiesSpawnedInCurrentWave;
	public GameObject enemyEasyToSpawn;
	public GameObject enemyHardToSpawn;

	private bool inBetweenWaves = false;
	public float timeBetweenWaves;
	private float timeLeftToAdvanceWave;
	// Use this for initialization
	void Start () {
		GameObject waveToInstantiate = waveInfo;
		waveToInstantiate.transform.FindChild("Image").GetComponent <Image> ().sprite = spriteWaveInfo[currentWave];
		Instantiate (waveToInstantiate);
		timeLeftToRespawn = timeToRespawn;
	}
	
	// Update is called once per frame
	void Update () {

		if (inBetweenWaves) {

			timeLeftToAdvanceWave -= Time.deltaTime;
			if (timeLeftToAdvanceWave <= 0) {

				inBetweenWaves = false;
				GameObject waveToInstantiate = waveInfo;
				waveToInstantiate.transform.FindChild("Image").GetComponent <Image> ().sprite = spriteWaveInfo[currentWave];
				Instantiate (waveToInstantiate);
			}
		} else {

			timeLeftToRespawn -= Time.deltaTime;
			if (timeLeftToRespawn <= 0f) {
				
				float gateToRespawn = Random.Range (0, respawnPoints.Length);

				float chanceOfHardEnemy = ((float) (currentWave + 1) / (numberOfEnemiesPerWave.Length));
				print (chanceOfHardEnemy);
				GameObject enemyToSpawn = enemyEasyToSpawn;

				if (Random.value <= chanceOfHardEnemy) {
					
					enemyToSpawn = enemyHardToSpawn;
				}

				Instantiate (enemyToSpawn, respawnPoints[(int) gateToRespawn].position, Quaternion.identity);

				if (currentWave >= criticalWave) {
					
					gateToRespawn = Random.Range (0, respawnPoints.Length);
					
					Instantiate (enemyToSpawn, respawnPoints[(int) gateToRespawn].position, Quaternion.identity);

				}
				timeLeftToRespawn = timeToRespawn;
				numberOfEnemiesSpawnedInCurrentWave++;
			}
			if (numberOfEnemiesSpawnedInCurrentWave >= numberOfEnemiesPerWave[currentWave]) {
				
				currentWave++;
				numberOfEnemiesSpawnedInCurrentWave = 0;
				inBetweenWaves = true;
				timeLeftToAdvanceWave = timeBetweenWaves;
			}

		}
	}
}
