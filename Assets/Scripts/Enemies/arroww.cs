using UnityEngine;
using System.Collections;

public class arroww : MonoBehaviour
{

    private Transform target; 

   
    public float Power;  
    private Rigidbody2D myRB;
    private Collider2D myCL;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myCL = GetComponent<Collider2D>();
        target = GameObject.FindWithTag("Player").transform; 

        
        Power = 200f;

        if (target.position.x > transform.position.x)
        {
            myRB.AddForce(new Vector2(Power, 100));
            
        }

        else if (target.position.x < transform.position.x)
        {
            myRB.AddForce(new Vector2(-Power, 350));
            transform.Rotate(new Vector3(0, 0, 180));
        }

        Destroy(gameObject, 5);
        


    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            transform.parent = other.transform;
            Destroy(myRB);
            Destroy(myCL);
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        else if ((other.gameObject.tag != "Player") && (other.gameObject.tag != "enemyArcher"))
        {
            Destroy(myRB);
            Destroy(myCL);
        }

    }




    //public Vector3 swaper;

    void Update()
    {
        if (myRB != null)
        {
            Vector3 dir = myRB.velocity;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        

        
        //transform.position = new Vector3(swaper, 1, 1);

    }




}
