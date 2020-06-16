using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item 
{
    public Sprite itemSprite;
    public GameObject Prefab;
    string itemName;
    float itemCost;
    string informations;

    public string Informations
    {
        get{return informations;}
    }

    public string ItemCost
	{
		get { return itemName; }
	}

    public string ItemName
	{
		get { return itemName; }
	}

    
}

public class Weapon : Item
{
    float damage;
    int bullets;
    int bulletMax;
    bool withBullet;

    public float Damage
    {
        get{return damage;}
    }
    public int Bullets
    {
        get{return bullets;}
    }
    public int BulletMax
    {
        get{return bulletMax;}
    }


    public Weapon(string name, float Damage, int BulletMax, int Bullets)
    {
        damage = Damage;
        bulletMax = BulletMax;
        bullets = Bullets;
    }
}