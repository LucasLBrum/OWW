using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static Player singleton;//variavel static da mesma classe para criar um singleton.
    public CarterScene carterScene;//Personagem do jogador.

    public GameObject childrens;

    public GameObject meshPlayer;

    public QuestManager questManager;

    string playerName = null;//nome do player

    public string PlayerName
    {
        get{return playerName;}
    }

   private void Awake()
    {
        NoDestroy();//singleton
    }

    void NoDestroy()//criando singleton
    {
        //Faz com que o game object que possui esta classe não seja destruído ao trocar de cena
        DontDestroyOnLoad(gameObject); 

        if (singleton == null && singleton != this)
        {
            singleton = this;
            //Faz com que o game object que possui esta classe não seja destruído ao trocar de cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
