using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {
    //Novo Script de movimentaçao
    //Introduçao:
    //
    //O Janissary tem basicamente 3 estados diferentes que ele pode estar
    //esses estados determinarao que codigo sera executado
    //Esses estados sao: searching, following e attacking
    //Durante toda a execucao do codigo o janissary vai ficar variando entre esses tres
    //
    //A linha de raciocinio para a mudança entre esses estados eh a seguinte:
    //1-searching
    //2-caso a poland nao esteja no campo de visao:
    //	3-retorna a 1
    //4-following; seta timeAfterISaw = 0
    //5-caso ele se aproxime da poland o suciciente:
    //	6-attacking
    //	7-quando os codigos do attacking acabarem retorna a 4
    //8-caso ele perca a poland de vista && timeAfterIsaw > 2 segundos:
    //	retorn a 1
    //
    //A variavel timeAfterISaw serve como uma 'memoria' para o janissary, para que ele n desista de procurar no momento em que ela sair do campo de visao dele (oq seria suscetivel a bugs)
    //
    //Uma variavel chamada estado sera usada para guardar informacoes sobre o atual estado do janissary
    //Ela eh do tipo int em que cada numero representa um estado como a seguir:
    //0-searching
    //1-following
    //2-attacking
    private int estado = 0;
    //	VARIAVEIS QUE FAZEM REFERENCIA A COMPONENTES

    private Animator thisAnimator;
    private Animator arcoAnimator;
    private Collider2D  thisCollider;
    private SpriteRenderer expression;
    public Sprite exclamation;
    public Sprite interrogation;

    //  INICIALIZACAO DAS DEMAIS VARIAVEIS

    private RaycastHit2D saw; //Variavel que guarda informacoes sobre o raycast da visao do janissary
    private Transform target; //transform da poland
    private float timeAfterIsaw;//Tempo que faz desde que a polonia foi avistada. (serve pra decidir quando o janissary deve desistir de procurar)
    private int facingDirection = 1;//1=direita, -1=esquerda
    public LayerMask visaoJanissary;//Layer mask q armazena quais objetos podem ser 'vistos' pelo janissary. (serve principalmente para impedir q sua visao pare em si mesmo (em seu proprio collider)
    public float speed=1;
    public LayerMask barreiras;
    private int decision;
    private float counter;
    private float spriteCounter;
    private float contador=0f;
    public Transform arrow;
    public Transform Ponta;
  

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        thisAnimator = GetComponent<Animator>();
        arcoAnimator = GameObject.Find("Arco").GetComponent<Animator>();
        thisCollider = GetComponentInChildren<Collider2D>();
        expression = GameObject.Find("Expressions").GetComponent<SpriteRenderer>();
        
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
            if (spriteCounter > 0.7)
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
            thisAnimator.SetBool("walk", false);
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

        if (Mathf.Abs(target.position.x - transform.position.x) >= 6f && Mathf.Abs(target.position.x - transform.position.x) < 15f)
        {
            Walk();
            
            if (transform.position.x > target.position.x)
            {
                facingDirection = -1;
            }
            else
            {
                facingDirection = 1;
            }
        }       
        else if (Mathf.Abs(target.position.x - transform.position.x) < 6f && Mathf.Abs(target.position.x - transform.position.x) > 5.9f)
        {

            thisAnimator.SetBool("walk", false);
            Attack();
            if (transform.position.x > target.position.x)
            {
                facingDirection = -1;
                
            }
            else
            {

                facingDirection = 1;
                
            }

            if (Mathf.Abs(target.position.y - transform.position.y) < 0.5)
                
            estado = 2;                      
        }

        else 
        {
            
            Walk();
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

    void Attack()
    {
       
        if (contador <= Time.time)

        {
            
            Instantiate(arrow, Ponta.transform.position, Quaternion.identity);
          
            


            contador = Time.time + 1.5f; 
        }

      
     


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
            thisAnimator.SetBool("walk", false);
        else
        {       
                thisAnimator.SetBool("walk", true);
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
}
