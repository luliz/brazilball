using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Objetivo : MonoBehaviour
{

    public static int inimigos;   

    public Text inimigosT;


    // Update is called once per frame
    void Update()
    {

        inimigosT.text = inimigos.ToString() + ("/4");
        
    }
}
