using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMelee : Enemy
{
    Witch witch = new Witch("", 50, 50, 23); //Character da bruxa, é aqui onde é definido seus stattus
    public string witchName; //nome da bruxa para possíveis interações 

    private void Awake()
    {
        witch.characterPrefab = gameObject; //conectando o prefab do character á esse objeto
    }

    private void Start()
    {
        thisCharacter = witch; //o Character do componenete de "Enemy" vai receber a witch.
        witch.nameCharacter = witchName; //trocando o nome.
    }
}
