using UnityEngine;
using System.Collections;

public class PontoF : MonoBehaviour {
    public Transform arrow3;
    public Transform PontaF;
    private Transform target;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	public void Arrows() {
			Instantiate (arrow3, PontaF.transform.position, Quaternion.identity);
	}

}
