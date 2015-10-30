using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{

    public float fireRate = 0;
    public float Damage = 10;
    public LayerMask whatTohit;
    public AudioClip soundshoot;

    private float TimeToFire = 0f;

    private Transform Ponta;

    public Transform bullet;

    void Awake()
    {

        Ponta = transform.FindChild("Ponta");

    }

    void Update()
    {

        if (fireRate == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > TimeToFire)
            
                TimeToFire = Time.time + 1 / fireRate;
                Shoot();
            

        }
    }

    void Shoot()
    {

        AudioSource.PlayClipAtPoint(soundshoot, transform.position);
        Instantiate(bullet, Ponta.transform.position, Quaternion.identity);
        
    }
}
