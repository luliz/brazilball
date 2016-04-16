using UnityEngine;
using System.Collections;

public static class ParticleDeath : object {
	
	public static void Die (Transform tranformToDie, GameObject particles) {

		GameObject.Instantiate (particles, tranformToDie.position, Quaternion.identity); 
	}
}
