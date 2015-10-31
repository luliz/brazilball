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
        //Vector3 rotacion = new Vector3(0,0,180);

        if(GameObject.Find("Player").GetComponent<PlayerController>().right == true)
        {
            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
            Instantiate(bullet, Ponta.transform.position, Ponta.rotation);
        }

        if (GameObject.Find("Player").GetComponent<PlayerController>().right == false)
        {
            
                Ponta.Rotate(0, 0, 180);
             
            
            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
            Instantiate(bullet, Ponta.transform.position, Ponta.rotation);
            Ponta.Rotate(0, 0, 180);
        }
        
        

         contador = Time.time + 2;
     

        


    }
}
