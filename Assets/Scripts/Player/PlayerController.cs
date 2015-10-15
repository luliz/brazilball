using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{

    public Rigidbody2D myRigidBody2D;
    public float velocidade = 1f;
    private bool right = true;
    public Animator animator;
	public Animator swordAnimator;
	public float forcaPulo = 10;
	public bool grounded;
	private float attackCounter = 0;

	private GameManager gameManager;
	private PlayerStatus status;


    // Executado uma vez e logo no inicio.
    void Awake(){
		status = this.GetComponent<PlayerStatus> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }
    // Chamado a cada frame do jogo.(Uma grande quantidade de linhas no update pode gerar em alguns jogos um frame ruim)
    void Update(){

		attackCounter += Time.deltaTime;
        if (Input.GetKey(Controls.walkLeft) )
        { //Se o A(Ele chama o script Controls que é estatico) for apertado ele vai ativar a animação de correr.
            animator.SetBool("run", true);
            transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));
            
            if (right){
                Flip();
            }
        }
        else if (Input.GetKey(Controls.walkRight))
        {
            animator.SetBool("run", true);
            transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));
            if (!right){
                Flip();
            }
        }
        else
        {
            animator.SetBool("run", false);
        }

		if (Input.GetKeyDown (Controls.jump) && grounded) {

			myRigidBody2D.AddForce(new Vector2 (0, forcaPulo), ForceMode2D.Impulse);
		}

		if (Input.GetKeyDown (Controls.strongAttack) && attackCounter >= 0.5) {
			attackCounter = 0;
			swordAnimator.SetTrigger("attack");
		}

		if (Input.GetKeyDown (Controls.pause) && !status.gameOver && !GameManager.menuCreated) {
			gameManager.CreateMenu();
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





