using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour {
	
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
		Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
		Vector3 destination = transform.position + delta;
		if (!(transform.position.y - destination.y > 0.5 || destination.y - transform.position.y > 0.5))
			destination.y = transform.position.y;

		transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		
	}
}