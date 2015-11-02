using UnityEngine;
using System.Collections;

public class limites : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay2D (Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            transform.GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        transform.GetComponent<Collider2D>().enabled = true;
    }
}
