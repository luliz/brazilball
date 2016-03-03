using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AIzarabatana : MonoBehaviour
{

    private float contador;
    public int health = 2;
    public Transform arrow;
    public Transform Ponta;
    public AudioClip soundshoot;
    public Transform target;

    public int enemyID;

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


    public void Take()
    {
        
        if (BasicAI.health > 0)
        {

            BasicAI.health--;
        }
        else
        {
            pontuacao.pontos += 30;
            Objetivo.inimigos++;
            GameManager.enemiesKilled.Add(this.enemyID);
            Destroy(this.gameObject);
        }
    }




}
