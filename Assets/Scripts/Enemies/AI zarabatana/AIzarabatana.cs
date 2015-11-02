using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIzarabatana : MonoBehaviour
{

    private float contador;
    public Transform arrow;
    public Transform Ponta;
    public AudioClip soundshoot;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        contador += Time.deltaTime;

        if (target.transform.position.x >  transform.position.x)
        {
            transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }

        if (target.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1.25f, 1.25f, 1.25f);
        }

        if (contador >= 2)
        {
            Instantiate(arrow, Ponta.transform.position, Ponta.rotation);
            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
            contador = 0;
        }
    }

    protected void Flip()
    {
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, 1);
    }
}
