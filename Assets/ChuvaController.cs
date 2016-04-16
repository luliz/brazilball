using UnityEngine;
using System.Collections;

public class ChuvaController : MonoBehaviour {

	public Transform target;

	// Update is called once per frame
	void Update () {
	
		transform.position = new Vector2 (target.position.x, transform.position.y); 
	}
}
