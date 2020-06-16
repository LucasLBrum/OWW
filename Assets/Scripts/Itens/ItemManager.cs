using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Weapon pistol = new Weapon("Pistola", 10, 5, 5);
    public GameObject pistolPrefab;
    public Sprite pistolStrite;

    Weapon shotGun = new Weapon("ShotGun", 20, 4, 2);
    public GameObject shotGunPrefab;
    public Sprite shotGunStrite;

    Weapon carabina = new Weapon("Carabina", 30, 6, 6);
    public GameObject carabinaPrefab;
    public Sprite carabinaStrite;

    /// <summary>
    //Criando as Armas que o jogador vai poder utilizar
    /// </summary>
    void Awake()
    {
        pistolPrefab = pistol.Prefab;
        pistolStrite = pistol.itemSprite;

        shotGunPrefab = shotGun.Prefab;
        shotGunStrite = shotGun.itemSprite;

        carabinaPrefab = carabina.Prefab;
        carabinaStrite = carabina.itemSprite;
    }
}
