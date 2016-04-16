using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AINordestinoRifle : MonoBehaviour
{

	private float contador = 1;
	public int health = 0;
	public GameObject arrow;
	public Transform Ponta;
	public AudioClip soundshoot;
	public Transform target;
	protected int facingDirection = 1;
	public int enemyID;

	private float speed = 2 ;
	public Animator animator;
	public Collider2D thisCollider;
	public LayerMask barreira;
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		thisCollider = GetComponentInChildren<Collider2D>();

	}
	void Update()
	{

		if (transform.position.x > target.position.x)
		{
			facingDirection = -1;
			Flip() ;

			if (Mathf.Abs(target.position.x - transform.position.x) > 5)
			{
				if (Mathf.Abs (target.position.x - transform.position.x) < 10) {
					facingDirection = -1;
					Walk ();
				}
			}

			else
			{
				contador += Time.deltaTime;
				if (contador >= 2)
				{
					GameObject currentBullet = (GameObject) Instantiate(arrow, Ponta.transform.position, Quaternion.identity);
					
					currentBullet.GetComponent<bullet> ().moveSpeed *= facingDirection;
					currentBullet.GetComponent<bullet> ().canKillEnemy = false;
					AudioSource.PlayClipAtPoint(soundshoot, transform.position);
					contador = 0;
				}
				animator.SetBool("walk", false);


			}






		}
		else
		{
			facingDirection = 1;
			Flip();
			if (Mathf.Abs(target.position.x - transform.position.x) > 5)
			{
				if (Mathf.Abs (target.position.x - transform.position.x) < 10) {
					facingDirection = 1;
					Walk ();
				}
			}

			else
			{
				contador += Time.deltaTime;
				if (contador >= 2)
				{
					GameObject currentBullet = (GameObject) Instantiate(arrow, Ponta.transform.position, Quaternion.identity);

					currentBullet.GetComponent<bullet> ().moveSpeed *= facingDirection;
					currentBullet.GetComponent<bullet> ().canKillEnemy = false;
					AudioSource.PlayClipAtPoint(soundshoot, transform.position);
					contador = 0;
				}
				animator.SetBool("walk", false);


			}
		}




	}

	protected void Flip()
	{
		transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * facingDirection, transform.localScale.y, 1);
	}


	public void Take()
	{

		if (health > 0)
		{

			health--;
		}
		else
		{
			pontuacao.pontos += 30;
			Objetivo.inimigos++;
			GameManager.enemiesKilled.Add(this.enemyID);
			Destroy(this.gameObject);
		}
	}

	void Walk()
	{      

		animator.SetBool("walk", true);
		transform.Translate(new Vector2(speed * facingDirection * Time.deltaTime, 0));
	}
}




