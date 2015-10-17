using UnityEngine;
using System.Collections;

public class PontoF : MonoBehaviour {
    public Transform arrow3;
    public Transform PontaF;
    public float contador;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (contador < Time.time)
        {
            Instantiate(arrow3, PontaF.transform.position, Quaternion.identity);
            contador = Time.time + 3f;
        }
    }
}
