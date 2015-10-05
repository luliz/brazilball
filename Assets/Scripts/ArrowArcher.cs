using UnityEngine;
using System.Collections;

public class ArrowArcher : MonoBehaviour {


    public float fireRate = 0;
    public float timeToFire = 0;
    public Transform Ponta;
    public Transform arrow;


	// Use this for initialization
	void Start () {
        Ponta = transform.FindChild("Ponta");
         
        
    }

    // Update is called once per frame
    void Update () {
       
	}

    void Atirar()
    {
        Instantiate(arrow, Ponta.transform.position, Ponta.rotation);
    }
}
