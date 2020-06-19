using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character //classe base de todo personagem no jogo.
{
    public GameObject characterPrefab;//prefab do character
    public string nameCharacter;//nome do character
    public float lifeCharacter;//vida do character
}

public class Carter : Character//classe do personagem principal que tem varios diferenciais dos demais personagens.
{
    public float stamina;//variavel que controla a stamina do personagem, assim controlando a quantida de pulos e corridas que ele pode dar com determinado valor da mesma.
    public Inventory inventory;//inventario do persoangem.
    public Carter(string Name, float Life, float Stamina) //contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        stamina = Stamina;
    }
}

public class Witch : Character//classe da bruxa que tem varios diferenciais dos demais personagens.
{
    public float magic;//variavel que demonstra o dano da bruxa.
    public Witch(string Name, float Life, float Magic)//contrutor
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        magic = Magic;
    }
}
