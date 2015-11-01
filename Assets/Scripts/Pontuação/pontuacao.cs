using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pontuacao : MonoBehaviour {

    public static int moedas;
    public static int pontos;

    public Text moedasT;
    public Text pontosT;
    

	// Update is called once per frame
	void Update () {

        moedasT.text = moedas.ToString();
        pontosT.text = pontos.ToString();
		print (PlayerPrefs.GetInt ("highscore"));
    }
}
