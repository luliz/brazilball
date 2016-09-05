using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fase3spawn : MonoBehaviour {

	//criticalWave eh a wave a partir da qual comecara a spawnar dois inimigos ao mesmo tempo

	public int nextLevel;

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

	Transform parentInimigos;
	bool ended = false;
	float finalTimer = 2f;
	// Use this for initialization
	void Start () {
		GameObject waveToInstantiate = waveInfo;
		waveToInstantiate.transform.FindChild("Image").GetComponent <Image> ().sprite = spriteWaveInfo[currentWave];
		Instantiate (waveToInstantiate);
		timeLeftToRespawn = timeToRespawn;
		parentInimigos = GameObject.Find ("parentInimigos").transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (!ended) {
			if (inBetweenWaves) {

				timeLeftToAdvanceWave -= Time.deltaTime;
				if (timeLeftToAdvanceWave <= 0) {

					inBetweenWaves = false;
					GameObject waveToInstantiate = waveInfo;
					waveToInstantiate.transform.FindChild ("Image").GetComponent <Image> ().sprite = spriteWaveInfo [currentWave];
					Instantiate (waveToInstantiate);
				}
			} else {

				timeLeftToRespawn -= Time.deltaTime;
				if (timeLeftToRespawn <= 0f) {
				
					float gateToRespawn = Random.Range (0, respawnPoints.Length);

					float chanceOfHardEnemy = ((float)(currentWave + 1) / (numberOfEnemiesPerWave.Length));
					print (chanceOfHardEnemy);
					GameObject enemyToSpawn = enemyEasyToSpawn;

					if (Random.value <= chanceOfHardEnemy) {
					
						enemyToSpawn = enemyHardToSpawn;
					}

					GameObject instantiated = (GameObject) Instantiate (enemyToSpawn, respawnPoints [(int)gateToRespawn].position, Quaternion.identity);
					instantiated.transform.SetParent (parentInimigos);
					if (currentWave >= criticalWave) {
					
						gateToRespawn = Random.Range (0, respawnPoints.Length);
					
						//new Vector3(respawnPoints [(int)gateToRespawn].position.x + Random.Range(1, 2), respawnPoints [(int)gateToRespawn].position.y, respawnPoints [(int)gateToRespawn].position.z);
					
						instantiated = (GameObject) Instantiate (enemyToSpawn, new Vector3(respawnPoints [(int)gateToRespawn].position.x + Random.Range(-1f, 1f), respawnPoints [(int)gateToRespawn].position.y, respawnPoints [(int)gateToRespawn].position.z), Quaternion.identity);
						instantiated.transform.SetParent (parentInimigos);
					}
					timeLeftToRespawn = timeToRespawn;
					numberOfEnemiesSpawnedInCurrentWave++;
				}
				if (numberOfEnemiesSpawnedInCurrentWave >= numberOfEnemiesPerWave [currentWave]) {
				
					currentWave++;
					numberOfEnemiesSpawnedInCurrentWave = 0;
					inBetweenWaves = true;
					timeLeftToAdvanceWave = timeBetweenWaves;
					if (currentWave == numberOfEnemiesPerWave.Length) {
						ended = true;
					}
				}

			}
		} else {

			if (parentInimigos.transform.childCount == 0) {

				finalTimer -= Time.deltaTime;
				if (finalTimer <= 0) {

					SceneManager.LoadScene (nextLevel);
				}
			}
		}
	}
}
