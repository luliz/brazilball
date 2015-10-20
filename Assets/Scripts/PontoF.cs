using UnityEngine;
using System.Collections;

public class PontoF : MonoBehaviour {
    public Transform arrow3;
    public Transform PontaF;
    public float contador;
    private Transform target;
    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (contador < Time.time)
        {
            if (target.position.x > 186)
            {
                Instantiate(arrow3, PontaF.transform.position, Quaternion.identity);
                contador = Time.time + 5f;
            }
        }
    }
}
