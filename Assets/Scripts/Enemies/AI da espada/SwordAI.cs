using UnityEngine;
using System.Collections;

public class SwordAI : MonoBehaviour {

    private int estado = 0;

    //	VARIAVEIS QUE FAZEM REFERENCIA A COMPONENTES

    private Animator thisAnimator;
    private Animator SwordAnimator;
    private Rigidbody2D thisCollider;
    private SpriteRenderer expression;
    public Sprite exclamation;
    public Sprite interrogation;

    //  INICIALIZACAO DAS DEMAIS VARIAVEIS

    private RaycastHit2D saw; //Variavel que guarda informacoes sobre o raycast da visao do janissary
    private Transform target; //transform da poland
    private float timeAfterIsaw;//Tempo que faz desde que a polonia foi avistada. (serve pra decidir quando o janissary deve desistir de procurar)
    private int facingDirection = 1;//1=direita, -1=esquerda
    public LayerMask visaoJanissary;//Layer mask q armazena quais objetos podem ser 'vistos' pelo janissary. (serve principalmente para impedir q sua visao pare em si mesmo (em seu proprio collider)
    public float speed;
    public LayerMask barreiras;
    private int decision;
    private float counter;
    private float spriteCounter;
    private float contador3;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        thisAnimator = GetComponent<Animator>();
        SwordAnimator = GameObject.Find("EspadaAI").GetComponent<Animator>();
        thisCollider = GetComponent<Rigidbody2D>();
        expression = GameObject.Find("Expressions3").GetComponent<SpriteRenderer>();
    }
    
    void Update()

    {
        
        if (Found())
            estado = 1;

        if (estado == 0)
            Search();
        else if (estado == 1)
            Follow();
        else
            Attack();
            

        timeAfterIsaw += Time.deltaTime;
        Flip();

        if (expression.sprite != null)
        {
            spriteCounter += Time.deltaTime;
            if (spriteCounter > 2)
            {
                spriteCounter = 0;
                expression.sprite = null;
            }
        }
    }

    void Search()
    {

        if (decision == 1)
        {
            facingDirection = -1;
            Walk();
        }
        else if (decision == 2)
        {
            facingDirection = 1;
            Walk();
        }
        else
        {
            thisAnimator.SetBool("walking", false);
        }

        counter += Time.deltaTime;

        if (counter > 0.5)
        {
            decision = (int)Random.Range(1, 4);
            counter = 0;
        }
    }

    void Follow()
    {
        if (timeAfterIsaw > 3.5)
        {
            estado = 0;
            expression.sprite = interrogation;
        }

        if (Mathf.Abs(target.position.x - transform.position.x) >= 0.5f && Mathf.Abs(target.position.x - transform.position.x) < 10f)
        {
            Walk();
            thisAnimator.SetBool("walking", true);
            SwordAnimator.SetBool("atacar", false);

            if (transform.position.x > target.position.x)
            {
                facingDirection = -1;
            }
            else
            {
                facingDirection = 1;
            }

        }
        else  
        {
            thisAnimator.SetBool("walking", false);
            SwordAnimator.SetBool("atacar", true);



            if (transform.position.x > target.position.x)
            {
                facingDirection = -1;


            }
            else
            {
                facingDirection = 1;

            }


        }
    }      

    void Attack()
    {       
        
        //TODO depois da animacao feita fazer o script de ataque
        //por enquanto ele simplesmente retorna ao estado 1
        
    }

    bool Found()
    {
        saw = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.1f), Vector2.right * facingDirection, 10f, visaoJanissary);
        if (saw.transform == target)
        {
            
            timeAfterIsaw = 0;
            if (estado == 0)
                expression.sprite = exclamation;
            
            return true;
        }
        return false;
    }

    void Walk()
    {

        if (thisCollider.IsTouchingLayers(barreiras))
            thisAnimator.SetBool("walking", false);
        else
        {
            thisAnimator.SetBool("walking", true);
            transform.Translate(new Vector2(speed * facingDirection * Time.deltaTime, 0));
        }
    }


    //Mudei um pouco o funcionamento do Flip()
    //Agora ele eh chamado todo frame
    //fazendo o flip quando necessario
    //diminuindo a chance de bugs
    //quem conseguir pensar numa maneira menos idiota de fazer isso pode faze-lo
    //talvez eu mesmo faça isso dps

    void Flip()
    {
        transform.localScale = new Vector3(facingDirection, 1, 1);
        expression.transform.localScale = new Vector3(facingDirection, 1, 1);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="limites")
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaa");
            facingDirection = facingDirection * -1;
        }
        
    }
}
