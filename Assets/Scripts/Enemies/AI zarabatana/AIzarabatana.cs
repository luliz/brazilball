using UnityEngine;

public class AIzarabatana : BasicAI
{

    public AudioSource audioSource;
    private float counter;
    private float contador;
    public Transform arrow;
    public Transform Ponta;
    private float contador2;
    public AudioClip soundshoot;
    private float contador3 = 0f;

    void Start()
    {
        speed = 5;
        health = 1;
        memory = 10f;
        minDistanceToAttack = 4f;
        maxDistanceToAttack = 5f;
        maxDistanceToFollow = 20f;
        raycastOffset = 0.1f;
        maxVerticalDistanceToAttack = 0.5f;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void DoExtraStuff()
    {
        if (contador3 > 5)
        {
            speed = 2;

        }
    }

    public override void Follow()
    {

    }

    public override void Attack()
    {

        if (contador <= Time.time)
        {
            weaponAnimator.SetBool("atirar", true);
            Instantiate(arrow, Ponta.transform.position, Quaternion.identity);
            contador = Time.time + 2f;
            contador2 = 0f;
            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
            estado = 1;
            contador3 = contador3 + 1;
        }
    }

    public override void TakeDamage()
    {

        audioSource.Play();

        if (health > 0)
        {

            health--;
        }
        else
        {
            GameManager.enemiesKilled.Add(this.enemyID);
            Destroy(this.gameObject);
        }
    }
}
