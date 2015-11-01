using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pontuacao : MonoBehaviour {

    public int moedas;
    public int pontos;

    public Text moedasT;
    public Text pontosT;
    
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        moedasT.text = moedas.ToString();
        pontosT.text = pontos.ToString();

    }
}
