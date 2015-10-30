using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{

    public Transform gun;
 
    private Rigidbody2D myRB;
    private Collider2D myCL;



    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myCL = GetComponent<Collider2D>();

        



       

            myRB.AddForce(new Vector2(1000, 50));
       
          
       

        Destroy(gameObject, 3);

    }


}
