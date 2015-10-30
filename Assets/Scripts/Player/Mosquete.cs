using UnityEngine;
using System.Collections;

public class Mosquete : MonoBehaviour {


    public int rotationOffset = 90;

    void Update ()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //subtracting the position of the player from the mouse position

        difference.Normalize(); //normalizing the vector.Meaning that all the sym of the vector will be equal to 1

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Find the angle in dregrees

        
        transform.rotation=Quaternion.Euler(0f,0f,rotZ  );

}

}

