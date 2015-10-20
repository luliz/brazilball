using UnityEngine;
using System.Collections;

public class arroww2 : MonoBehaviour
{
    private Transform target;   
    private Rigidbody2D myRB;
    private Collider2D myCL;
    private float absDistance;
    private float Power;

    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myCL = GetComponent<Collider2D>();
        target = GameObject.FindWithTag("Player").transform;
        absDistance = Mathf.Abs(transform.position.x - target.position.x);
        Power = (1000 * absDistance) / 14;

        if (target.position.x > transform.position.x)
        {
            myRB.AddForce(new Vector2(Power, 0));
            transform.Rotate(new Vector3(0, 0, 270));
        }

        else if (target.position.x < transform.position.x)
        {
            myRB.AddForce(new Vector2(-Power, 0));
            transform.Rotate(new Vector3(0, 0, 270));
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
        else if ((other.gameObject.tag != "enemyArcher"))
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
  