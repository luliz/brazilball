using UnityEngine;
using System.Collections;

public class Archer2 : MonoBehaviour {

    private int estado = 0;    
   
    private SpriteRenderer expression;
    public Sprite exclamation;
    public Sprite interrogation;
    private RaycastHit2D saw; //Variavel que guarda informacoes sobre o raycast da visao do janissary
    private Transform target; //transform da poland
    private float timeAfterIsaw;//Tempo que faz desde que a polonia foi avistada. (serve pra decidir quando o janissary deve desistir de procurar)
    private int facingDirection = 1;//1=direita, -1=esquerda
    public LayerMask visaoJanissary;//Layer mask q armazena quais objetos podem ser 'vistos' pelo janissary. (serve principalmente para impedir q sua visao pare em si mesmo (em seu proprio collider)      
    private int decision;
    private float counter;
    private float spriteCounter;
    private float contador;
    public Transform arrow;
    public Transform Ponta;
   
    private float contador2 =0f;
    public AudioClip soundshoot;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        expression = GameObject.Find("Expressions4").GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Found())
            estado = 1;
        
        if (estado == 1)
            Follow();
        if (transform.position.x > target.position.x)
        {
            facingDirection = -1;
        }
        else
        {
            facingDirection = 1;
        }


        timeAfterIsaw += Time.deltaTime;
        Flip();

        if (expression.sprite != null)
        {
            spriteCounter += Time.deltaTime;
            if (spriteCounter > 0.7)
            {
                spriteCounter = 0;
                expression.sprite = null;
            }
        }        
    }
    void Follow()
    {
        if (timeAfterIsaw > 3.5)
        {
            estado = 0;
            expression.sprite = interrogation;
        }
        if (target.position.x > transform.position.x)
        {

            
            if (contador2 > Time.time)

                Attack();
            else
                contador2 = Time.time + 0.1f;
        }

        if (target.position.x < transform.position.x)
        {

            
            if (contador2 > Time.time)

                Attack();
            else
                contador2 = Time.time + 2f;
        }
    }
    void Attack()
    {
        if (contador <= Time.time)
        {
            Instantiate(arrow, Ponta.transform.position, Quaternion.identity);
            contador = Time.time + 1f;
            contador2 = 0f;
            AudioSource.PlayClipAtPoint(soundshoot, transform.position);
        }
    }
    bool Found()
    {       
        if (target.position.x >= 78f  && target.position.x < 85f) 
        {
            timeAfterIsaw = 0;
            if (estado == 0)
                expression.sprite = exclamation;
            return true;
        }


        return false;
    }
    void Flip()
    {
        transform.localScale = new Vector3(facingDirection, 1, 1);
        expression.transform.localScale = new Vector3(facingDirection, 1, 1);
    }
}
