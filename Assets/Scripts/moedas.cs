using UnityEngine;
using System.Collections;

public class moedas : MonoBehaviour
{

    public Animator animator;
    public AudioClip soundshoot;

    public GameObject pontuacao;

 
    // Use this for initialization
 

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("movimento", true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            pontuacao.GetComponent<pontuacao>().moedas++;
            pontuacao.GetComponent<pontuacao>().pontos+=10;

            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
            
            Destroy(this.gameObject);
        }

    }



}
