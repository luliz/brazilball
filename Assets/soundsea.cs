using UnityEngine;
using System.Collections;

public class soundsea : MonoBehaviour {

	public Transform target ;
    public AudioSource soundofgame;
   


    // Update is called once per frame
    void Update () {
        if (transform.position.x < target.transform.position.x)
        {
            soundofgame.Play();
        }
	}
}
