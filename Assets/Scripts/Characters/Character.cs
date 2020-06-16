using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character 
{
    public GameObject characterPrefab;
    public string nameCharacter;
    public float lifeCharacter;
    public Inventory myInventory = new Inventory();
}

public class Carter : Character
{
    public float stamina;
    public Carter(string Name, float Life, float Stamina)
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        stamina = Stamina;
    }
}

public class Witch : Character
{
    public float magic;
    public Witch(string Name, float Life, float Magic)
    {
        nameCharacter = Name;
        lifeCharacter = Life;
        magic = Magic;
    }
}
