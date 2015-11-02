using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour
{
    public int moveSpeed = 23;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "arrow"))
        {
            Destroy(gameObject);
        }
    }
}
