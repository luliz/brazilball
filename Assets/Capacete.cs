﻿using UnityEngine;
using System.Collections;

public class Capacete : MonoBehaviour {

	public int hatID;

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Player") {

            Vidas.capacetes++;     
            
			GameManager.hatsPicked.Add (hatID);
			PlayerStatus.lives++;
			Destroy (gameObject);
		}
	}
}
