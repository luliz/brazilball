using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

   
    public AudioClip soundshoot;

  

    private Transform Ponta;

    public Transform bullet;
    float contador = 0f;

    void Awake()
    {

        Ponta = transform.FindChild("Ponta");

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && contador < Time.time)
        {
            Shoot();

        }
        
        
    }

    void Shoot()
    {

        AudioSource.PlayClipAtPoint(soundshoot, transform.position);
        Instantiate(bullet, Ponta.transform.position, Ponta.rotation);
        contador = Time.time + 2;


    }
}
