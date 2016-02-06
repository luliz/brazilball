using UnityEngine;
using System.Collections;

public class Eliminado : MonoBehaviour
{
    public int coinID;
   


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Objetivo.inimigos++;                  

            GameManager.coinsPicked.Add(this.coinID);
            Destroy(this.gameObject);
        }

    }



}
