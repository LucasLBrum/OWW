using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchRangedScene : CharacterScene
{
    public PotionSlow potion;
    public GameObject potionObjectE;
    public GameObject potionObjectS;
    public GameObject pivot;

    WitchRanged witchRanged = new WitchRanged("", 100, 100, 10);

    private void Awake()
    {
        witchRanged.characterPrefab = gameObject;
        anim = GetComponent<Animator>();
        thisCharacter = witchRanged;
    }
    public void SpawnPotion()
    {
        int a = Random.Range(1, 3);
        if(a == 1)
        {
            
            var potionT = Instantiate(potionObjectS, pivot.transform.position, Quaternion.identity, pivot.transform.parent);
            this.potion = potionT.GetComponent<PotionSlow>();
            transform.LookAt(Player.singleton.carterScene.transform);
        }
        else
        {
            var potionT = Instantiate(potionObjectE, pivot.transform.position, Quaternion.identity, pivot.transform.parent);
            this.potion = potionT.GetComponent<PotionSlow>();
            transform.LookAt(Player.singleton.carterScene.transform);
        }
    }
    public void PlayPotion()
    {
        if(potion != null)
        {
            potion.TakeImpulse(Player.singleton.carterScene.gameObject);
        }
    }
}
