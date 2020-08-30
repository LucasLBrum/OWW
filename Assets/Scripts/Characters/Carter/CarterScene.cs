using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarterScene : CharacterScene
{
    public GameObject carterPrefab;//prefab public do personagem para refêrenciar no script do personagem.
    public Inventory inventoryInScene;//inventario presente na cena; 
    public Carter carter = new Carter("Carter", 100, 100, 25, 25, 0.1f);//Personagem principal
    public CarterStatus carterStatus; 

    private void Awake()
    {
        carterStatus = GetComponent<CarterStatus>();
        thisCharacter = carter;
        carter.characterPrefab = carterPrefab;//refêrenciando.
        carter.inventory = inventoryInScene;//refêrenciando.
    }
}
