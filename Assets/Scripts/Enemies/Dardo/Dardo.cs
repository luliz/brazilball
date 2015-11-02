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
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Power = 500;

        if (target.position.x > transform.position.x)
        {
            if (Mathf.Abs(target.position.x - transform.position.x) < 4)
            {
                myRB.AddForce(new Vector2(600, 100));
            }
            else
            {
                myRB.AddForce(new Vector2(Power, 100));
            }


        }

        else if (target.position.x < transform.position.x)
        {

            if (Mathf.Abs(target.position.x - transform.position.x) < 4)
            {
                myRB.AddForce(new Vector2(-600, 100));
            }
            else
            {
                myRB.AddForce(new Vector2(-Power, 100));
            }
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
        if ((other.gameObject.tag != "enemy"))
        {
            Destroy(myRB);
            Destroy(myCL);
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