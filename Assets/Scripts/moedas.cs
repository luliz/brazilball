using UnityEngine;
using System.Collections;

public class moedas : MonoBehaviour {

    public Animator animator;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        animator.SetBool("movimento",true);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {           
            Destroy(this.gameObject);            
        }


    }
}
