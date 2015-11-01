using UnityEngine;
using System.Collections;

public class moedas : MonoBehaviour
{
	public int coinID;
    public Animator animator;
    public AudioClip soundshoot;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            pontuacao.moedas++;
            pontuacao.pontos+=10;

            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
            
			GameManager.coinsPicked.Add(this.coinID);
            Destroy(this.gameObject);
        }

    }



}
