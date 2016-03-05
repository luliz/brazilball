using UnityEngine;
using System.Collections;

public class Dardo : MonoBehaviour {

    public Transform target;
    private float absDistance;
    private float Power;
    private Rigidbody2D myRB;
    private Collider2D myCL;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myCL = GetComponent<Collider2D>();
    
        target = GameObject.FindGameObjectWithTag("cavalinho").transform;


   
        
        Power = 100;

        if (target.position.x > transform.position.x)
        {
            myRB.AddForce(new Vector2(Power, 0));
        }

        else if (target.position.x < transform.position.x)
        {
            myRB.AddForce(new Vector2(-Power, 0));
        }


        Destroy(gameObject, 7);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent = other.transform;
            Destroy(myRB);
            Destroy(myCL);
			int parentFacingDirection = (int) transform.parent.localScale.x;
			GameObject.Find("Player").GetComponent<PlayerStatus>().TakeDamage(parentFacingDirection);
        }

        if ((other.gameObject.tag != "enemy"))
        {
            Destroy(myRB);
            Destroy(myCL);
        }

        if ((other.gameObject.tag == "Bullet"))
        {
            Destroy(gameObject);
        }
		
    }
    
}