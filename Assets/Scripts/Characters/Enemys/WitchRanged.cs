using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchRanged : Enemy
{
    Animator anim;
    public PotionSlow potion;
    public GameObject potionObject;
    public GameObject pivot;

    private void Start()
    {

        anim = GetComponent<Animator>();
        TakePotion();
    }

    public void Atack()
    {

        var potion = Instantiate(potionObject, pivot.transform.position, Quaternion.identity, pivot.transform.parent);
        this.potion = potion.GetComponent<PotionSlow>(); 
        transform.LookAt(Player.singleton.carterScene.transform);
        anim.SetTrigger("Atack");
    }

    public void TakePotion()
    {
        if(GetComponentInChildren<PotionSlow>() != null)
        {
            potion = GetComponentInChildren<PotionSlow>();
        }
    }

    public void PlayPotion()
    {
        if(potion != null)
        {
            potion.TakeImpulse(Player.singleton.carterScene.gameObject);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
            Atack();
    }
}
