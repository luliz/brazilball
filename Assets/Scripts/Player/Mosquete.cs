using UnityEngine;
using System.Collections;

public class Mosquete : MonoBehaviour {



    public int rotationOffset;
    public Transform target;
    private bool right = true;

  
        void Update ()
    {
   


        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (dir.x >= 0)
        {
            right = true;

            print(" right? ");
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

             float x = transform.localScale.x ;
            Vector3 ls = transform.localScale;
        }
        else
        {
            right = false;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
            

            float x = -transform.localScale.x;
            Vector3 ls = -transform.localScale;
        }

    }


}



