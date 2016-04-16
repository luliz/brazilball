using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    public int moveSpeed = 23;
	public bool canKillEnemy = true;
	void Start () {

		if (SceneManager.GetActiveScene ().name == "Fase 3") {

			transform.localScale = Vector3.one * 2;
			moveSpeed /= 2;

		}
			
	}

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1.5f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		if ((other.gameObject.tag == "enemy"))
        {	
			if (canKillEnemy) {
				if (other.gameObject.GetComponent<BasicAI> ())
					other.gameObject.GetComponent<BasicAI> ().TakeDamage ();
				if (other.gameObject.GetComponent<enemyOnHorseAI> ())
					other.gameObject.GetComponent<enemyOnHorseAI> ().Die ();
				if (other.gameObject.GetComponent<AINordestinoRifle> ())
					other.gameObject.GetComponent<AINordestinoRifle> ().Take ();
				Destroy (gameObject);
			} else {

				Physics2D.IgnoreCollision (GetComponent<CircleCollider2D> (), other.collider);
			}
        }

		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<PlayerStatus> ().TakeDamage ();
			Destroy (gameObject);
		}
    }
}
