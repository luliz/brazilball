using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = -1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI ()
    {

        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        //colocar cor
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);                //define o valor alpha
        GUI.depth = drawDepth;                                                              //faz a textura ser renderizada no topo de tudo
        GUI.DrawTexture( new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);     //desenha a textura na tela
    }

    //define a direção do fade para fazer com que a cena fade in com -1 e fade out com 1

    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (fadeSpeed);
    }

    void OnLevelWasLoaded () //essa função é chamada quando uma cena é carregada, como parametro ela recebe o index da cena então podemos limitar a quantidades de cenas que o fade vai funcionar
    {
        //alpha = 1;    //pode utilizar essa linha de código caso o alpha não esteja setado automaticamente para 1
        BeginFade(-1);  //executa o fade
    }
}
