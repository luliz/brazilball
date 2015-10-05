using UnityEngine;
using System.Collections;

public class arroww : MonoBehaviour
{

    private Transform target; 

    private float absDistance; 
    private float Power;  
    public Rigidbody2D myRB;

   
    void Start()
    {
        myRB = GetComponentInChildren<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; 

        absDistance = Mathf.Abs(transform.position.x - target.position.x); 
        Power = (1000 * absDistance) / 37;

        if (target.position.x > transform.position.x)
        {
            myRB.AddForce(new Vector2(Power, 400));
            transform.Rotate(new Vector3(0, 0, 180));
        }

        else if (target.position.x < transform.position.x)
        {
            myRB.AddForce(new Vector2(-Power, 400));
            transform.Rotate(new Vector3(0, 0, 360));
        }

    }
    
}
