﻿using UnityEngine;
using System.Collections;

public class arroww : MonoBehaviour
{

    private Transform target; 

   
    public float Power;  
    public Rigidbody2D myRB;

   
    void Start()
    {
        myRB = GetComponentInChildren<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform; 

        
        Power = 800f;

        if (target.position.x > transform.position.x)
        {
            myRB.AddForce(new Vector2(Power, 50));
            
        }

        else if (target.position.x < transform.position.x)
        {
            myRB.AddForce(new Vector2(-Power, 30));
            transform.Rotate(new Vector3(0, 0, 180));
        }
        Destroy(gameObject, 1);

    }



        


}
