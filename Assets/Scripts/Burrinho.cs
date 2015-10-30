using UnityEngine;
using System.Collections;

public class Burrinho : MonoBehaviour {

	public float speed = 5f;

	void Update () {

		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}
}
