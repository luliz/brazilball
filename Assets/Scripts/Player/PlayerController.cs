using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour{
	
	public Rigidbody2D myRigidBody2D;
	public float velocidade = 1f;
	private bool right = true;
	public Animator animator;
	public Animator weaponAnimator;
	public float forcaPulo = 10;
	public bool grounded;
	private float attackCounter = 0;
	private int weapon;
	private GameManager gameManager;
	private PlayerStatus status;
	
	public bool touchingLadder;
	public bool onLadder;
	public float lockedXPosition;
	public float climbSpeed = 1f;
	public static Vector3 playerSpawnPosition = new Vector3 (-34f, -4f);
    
    // Executado uma vez e logo no inicio.
    void Awake(){
		status = this.GetComponent<PlayerStatus> ();
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
       
    }

	void Start() {

		transform.position = playerSpawnPosition;
	}
	// Chamado a cada frame do jogo.(Uma grande quantidade de linhas no update pode gerar em alguns jogos um frame ruim)
	void Update(){
       
        if (onLadder && !touchingLadder) {
			
			onLadder = false;
			myRigidBody2D.gravityScale = 3;
		}
		if (transform.position.y < Camera.main.ScreenToWorldPoint (new Vector3 (0, Camera.main.orthographicSize - 100f, 0)).y) {
			
			gameManager.GameOver ();
		}
		
		attackCounter += Time.deltaTime;
		if (Input.GetKey(Controls.walkLeft) && !onLadder)
		{ //Se o A(Ele chama o script Controls que é estatico) for apertado ele vai ativar a animação de correr.
			animator.SetBool("run", true);
			transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));
			
			if (right){
				Flip();
			}
		}
		else if (Input.GetKey(Controls.walkRight) && !onLadder)
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
		
		if (Input.GetKeyDown (Controls.jump) && (grounded || onLadder)) {
			
			myRigidBody2D.AddForce(new Vector2 (0, forcaPulo), ForceMode2D.Impulse);
			myRigidBody2D.gravityScale = 3;
			onLadder = false;
		}
		
		if (Input.GetKeyDown (Controls.strongAttack) && attackCounter >= 0.5 && !onLadder) {
			attackCounter = 0;
			weaponAnimator.SetTrigger("attack2");
		}
		if (Input.GetKeyDown (Controls.attack) && attackCounter >= 0.5 && !onLadder &&grounded) {
			
			attackCounter = 0;
			weaponAnimator.SetTrigger("attack1");
		}
		
		
		if (Input.GetKey (Controls.climbLadderUp) && touchingLadder && !onLadder) {
			
			onLadder = true;
			transform.position = new Vector2 (lockedXPosition, transform.position.y);
			myRigidBody2D.velocity = new Vector2 (0, 0);
			myRigidBody2D.gravityScale = 0;
			
		}
		
		if (Input.GetKey (Controls.climbLadderUp) && onLadder) {
			
			transform.Translate (new Vector3 (0, climbSpeed * Time.deltaTime, 0));
		}
		
		if (Input.GetKey (Controls.climbLadderDown) && onLadder) {
			
			transform.Translate (new Vector3 (0, climbSpeed * Time.deltaTime * -1, 0));
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





