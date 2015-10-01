using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
    public Rigidbody2D myRigidBody2D;
    public float velocidade = 1f;
    private bool right = true;
    public Animator animator;
    public bool isgrounded;
    public Transform ground;
    public int force;
  
    // Executado uma vez e logo no inicio.
    void Start(){
      }
    // Chamado a cada frame do jogo.(Uma grande quantidade de linhas no update pode gerar em alguns jogos um frame ruim)
    void Update()
    {
        isgrounded = Physics2D.Linecast(this.transform.position,ground.position , 1 <<  LayerMask.NameToLayer("ground"));

        if (Input.GetKey(Controls.walkLeft))
        { //Se o A(Ele chama o script Controls que é estatico) for apertado ele vai ativar a animação de correr.
            animator.SetBool("run", true);
            transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));

            if (right)
            {
                Flip();
            }
        }
        else if (Input.GetKey(Controls.walkRight))
        {
            animator.SetBool("run", true);
            transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));
            if (!right)
            {
                Flip();
            }
        }
        else
        {
            animator.SetBool("run", false);
            
        }


        if (Input.GetKey(Controls.jump)    && isgrounded)
        {
            animator.SetBool("jump", true);
            myRigidBody2D.AddForce(transform.up * force);
                
        }
         else
        {
            
            animator.SetBool("jump", false);
        }
    }
    private void Flip(){
        // Troca pra onde o player ta olhando.
        right = !right;
        // Vira o player .
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}





