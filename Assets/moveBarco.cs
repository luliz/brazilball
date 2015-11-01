using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class moveBarco : MonoBehaviour {

    private int prosseguir;
    public Transform self;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        prosseguir = GameObject.Find("GameManager").GetComponent<GameManager>().index;

        if (self.transform.position.x < 27)
        {
            if (prosseguir >= 4)
            {
                if (transform.position.x > 25.25)
                {

                    transform.Translate(new Vector3(-0.5f * Time.deltaTime, 0, 0));
                }
            }
        }

        if (self.transform.position.x > 59)
        {
            if (prosseguir >= 7)
            {
                if (transform.position.x < 60.9)
                {
                    transform.Translate(new Vector3(0.5f * Time.deltaTime, 0, 0));
                }
            }
        }
        
    }
}
