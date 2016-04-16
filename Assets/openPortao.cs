using UnityEngine;
using System.Collections;

public class openPortao : MonoBehaviour {

	public GameObject boss;
    private int prosseguir;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        prosseguir = GameObject.Find("GameManager").GetComponent<GameManager>().index;
		print (prosseguir);
        if (prosseguir >= 13)
        {
			boss.SetActive (true);
            if(GameObject.Find("Player").transform.position.x <= 212.4 && transform.position.y < -3.15)
            {
                transform.Translate(new Vector3(0, 0.5f * Time.deltaTime, 0));
            }

            if (GameObject.Find("Player").transform.position.x >= 212.4 && transform.position.y > -4.06)
            {
                transform.Translate(new Vector3(0, -0.5f * Time.deltaTime, 0));
            }
        }
    }
}
