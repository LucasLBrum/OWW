using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchRanged : Enemy
{
    Animator anim;
    public PotionSlow potion;
    public GameObject potionObjectE;
    public GameObject potionObjectS;
    public GameObject pivot;

    private void Start()
    {

        anim = GetComponent<Animator>();
        TakePotion();
    }

    public void Atack()
    {
        int a = Random.Range(1, 3);
        if(a == 1)
        {
            var potion = Instantiate(potionObjectS, pivot.transform.position, Quaternion.identity, pivot.transform.parent);
            this.potion = potion.GetComponent<PotionSlow>();
            transform.LookAt(Player.singleton.carterScene.transform);
            anim.SetTrigger("Atack");
        }
        else
        {
            var potion = Instantiate(potionObjectE, pivot.transform.position, Quaternion.identity, pivot.transform.parent);
            this.potion = potion.GetComponent<PotionSlow>();
            transform.LookAt(Player.singleton.carterScene.transform);
            anim.SetTrigger("Atack");
        }
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
