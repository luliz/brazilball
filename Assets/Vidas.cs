using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Vidas : MonoBehaviour {

    public static int capacetes = 1;
    

    public Text CapacetesT;



    // Update is called once per frame
    void Update()
    {
        CapacetesT.text = capacetes.ToString();
        
    }
}
