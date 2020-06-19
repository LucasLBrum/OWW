using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarterScene : MonoBehaviour
{
    public GameObject carterPrefab;//prefab public do personagem para refêrenciar no script do personagem.
    public Inventory inventoryInScene;//inventario presente na cena; 
    public Carter carter = new Carter("Carter", 100 , 25);//Personagem principal

    private void Awake()
    {
        carter.characterPrefab = carterPrefab;//refêrenciando.
        carter.inventory = inventoryInScene;//refêrenciando.
    }
}
