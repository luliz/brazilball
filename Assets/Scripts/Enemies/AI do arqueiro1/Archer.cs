using UnityEngine;

public class Archer : BasicAI {

    private float counter;
    private float contador;
    public Transform arrow;
    public Transform Ponta;
    private float contador2;
    public AudioClip soundshoot;
    private float contador3 = 0f;

	void Start () {
		speed = 5;
		health = 1;
		memory = 10f;
		minDistanceToAttack = 4f;
		maxDistanceToAttack = 5f;
		maxDistanceToFollow = 20f;
		raycastOffset = 0.1f;
		maxVerticalDistanceToAttack = 0.5f;
		target = GameObject.Find ("Player").transform;
	}

    public override void DoExtraStuff() {
        if (contador3 > 5)
        {
            speed = 2;
            
        }
    }

    public override void Follow()
    {
        if (timeAfterISaw > memory)
        {
            estado = 0;
			if (expressions)
            	expressions.sprite = interrogation;
        }

		if (Mathf.Abs(target.position.x - transform.position.x) >= maxDistanceToAttack && Mathf.Abs(target.position.x - transform.position.x) < maxDistanceToFollow)
        {
            Walk();
            weaponAnimator.SetBool("atirar", true);

            if (transform.position.x > target.position.x)
            {
                facingDirection = -1;
            }
            else
            {
                facingDirection = 1;
            }

        }
        else if (Mathf.Abs(target.position.x - transform.position.x) < maxDistanceToAttack && Mathf.Abs(target.position.x - transform.position.x) > minDistanceToAttack)
        {

            animator.SetBool("walk", false);
            minDistanceToAttack = 2f;
            if (transform.position.x > target.position.x )
            {
                facingDirection = -1;                
            }
            else
            {
             facingDirection = 1;                
            }
			
			if (Mathf.Abs(target.position.y - transform.position.y) < maxVerticalDistanceToAttack) {
            	if(contador2 > Time.time)
					estado = 2;
            	else
            		contador2 = Time.time + 0.1f;
			}
        }
        else
        {
            Walk();
            minDistanceToAttack = 4f;       
                                    
            if (transform.position.x > target.position.x)
            {
                facingDirection = 1;
            }
            else
            {
                facingDirection = -1;
            }
        }               
    }
   
    public override void Attack() {

        if (contador <= Time.time) {
            weaponAnimator.SetBool("atirar", true);
			Instantiate(arrow, Ponta.transform.position, Quaternion.identity);
            contador = Time.time + 2f;
            contador2 = 0f;
            AudioSource.PlayClipAtPoint(soundshoot,transform.position);
			estado = 1;
            contador3 = contador3 + 1;
        }
	}

	public override void TakeDamage() {
		if (health > 0) {

			health--;
		} else {

			Destroy (this.gameObject);
		}
	}
}
