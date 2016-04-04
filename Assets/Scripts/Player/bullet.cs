using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public int moveSpeed = 23;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "enemy"))
        {	
			if (other.gameObject.GetComponent<BasicAI> ())
				other.gameObject.GetComponent<BasicAI> ().TakeDamage ();
			if (other.gameObject.GetComponent<enemyOnHorseAI> ())
				other.gameObject.GetComponent<enemyOnHorseAI> ().Die ();
			if (other.gameObject.GetComponent<AINordestinoRifle> ())
				other.gameObject.GetComponent<AINordestinoRifle> ().Take ();
			Destroy (gameObject);
        }

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerStatus> ().TakeDamage ();
			Destroy (gameObject);
		}
    }
}
