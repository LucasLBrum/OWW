using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarterScene : MonoBehaviour
{
    public GameObject carterPrefab;//prefab public do personagem para refêrenciar no script do personagem.
    public Inventory inventoryInScene;//inventario presente na cena; 
    public Carter carter = new Carter("Carter", 100, 100, 25, 25, 0.1f);//Personagem principal
    public CharacterStatus carterStatus; 

    private void Awake()
    {
        carter.characterPrefab = carterPrefab;//refêrenciando.
        carter.inventory = inventoryInScene;//refêrenciando.
    }

    public void Start()
    {
        carterStatus.UpdateUI(carter.lifeCharacter, carter.lifeFullCharacter, carterStatus.vidaImage);
        carterStatus.UpdateUI(carter.stamina, carter.staminaFull, carterStatus.staminaImage);
    }
}
