using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

    public GUIStyle customGUIStyle; 
    

    void OnGUI()
    {
       
        
        GUI.Button(new Rect(Screen.width / 60, 200, 150, 30), "Jogo produzido por alunos do" , customGUIStyle);
        GUI.Button(new Rect(Screen.width / 60, 220, 150, 30), "Curso de Informática do IFRN.", customGUIStyle);
        GUI.Button(new Rect(Screen.width / 60, 240, 150, 30), "Um jogo produzido para entreter", customGUIStyle); 
        GUI.Button(new Rect(Screen.width / 60, 260, 150, 30), "o jogador e proporcionar momentos", customGUIStyle);
        GUI.Button(new Rect(Screen.width / 60, 280, 150, 30), "educativos relacionados ao tema ", customGUIStyle);
        GUI.Button(new Rect(Screen.width / 60, 300, 150, 30), "de historia.", customGUIStyle);
        

    }
}
