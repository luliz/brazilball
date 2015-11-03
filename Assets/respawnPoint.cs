using UnityEngine;
using System.Collections;

public class respawnPoint : MonoBehaviour {

	public GameObject indioPrefab;

	public void Respawn () {

		Instantiate (indioPrefab, transform.position, Quaternion.identity);
	}
}
