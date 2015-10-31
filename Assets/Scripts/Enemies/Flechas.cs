using UnityEngine;
using System.Collections;

public class Flechas : MonoBehaviour {


    private Transform target;

    private float absDistance;
    private float Power;
    private Rigidbody2D myRB;
    private Collider2D myCL;
  
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myCL = GetComponent<Collider2D>();
        target = GameObject.FindWithTag("Player").transform;

        float x = Random.Range(200f, 300f);

        float y = Random.Range(20f, 50f);

        if (target.position.x > transform.position.x)
        {                         
          
                myRB.AddForce(new Vector2(x, y));
        }

        else if (target.position.x < transform.position.x)
        {
                    
            
            
                myRB.AddForce(new Vector2(-x, y));
            
        }
        Destroy(gameObject, 3);

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            transform.parent = other.transform;
            Destroy(myRB);
            Destroy(myCL);
            other.gameObject.GetComponent<PlayerStatus>().TakeDamage(1);



        }
        else if ((other.gameObject.tag != "enemyArcher") && other.gameObject.tag != "arrow")
        {
            Destroy(myRB);
            Destroy(myCL);
        }

        if ((other.gameObject.tag == "enemy"))
        {
            Destroy(gameObject);
        }
    }




void Update()
    {
        if (myRB != null)
        {
            Vector3 dir = myRB.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    
}
}
