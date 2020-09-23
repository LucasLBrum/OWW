using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchMelee : CharacterScene
{
    public Witch witch = new Witch("", 100, 100, 10);//Character da bruxa, é aqui onde é definido seus stattus
    private void Awake()
    {
        witch.characterPrefab = gameObject;
        anim = GetComponent<Animator>();
        thisCharacter = witch;
    }
}
