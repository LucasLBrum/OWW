using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public void PickUp(GameObject thisItem)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(thisItem.GetComponent<ItemScene>() != null)
            {
                if(thisItem.GetComponent<QuestElement>() != null)
                {
                    thisItem.GetComponent<QuestElement>().CompleteRequest();
                }
                ItemResource resorce = thisItem.GetComponent<ItemScene>().thisItem;//refêrencia do item do raycast
                Player.singleton.carterScene.inventoryInScene.VerificationItem(resorce, thisItem);//adiciona esse item ao inventario.
                GetComponent<AudioScript>().PickUpSound();
            }
            else if(thisItem.GetComponent<Munition>() != null)
            {
                int bullets = thisItem.GetComponent<Munition>().boxMunition;
                if (thisItem.GetComponent<Munition>().type == MunitionType.Big)
                {
                    Player.singleton.carterScene.inventoryInScene.munitionB.AddMunition(bullets);
                    GetComponent<AudioScript>().PickUpSound();
                    Destroy(thisItem);
                }
                else if(thisItem.GetComponent<Munition>().type == MunitionType.Little)
                {
                    Player.singleton.carterScene.inventoryInScene.munitionL.AddMunition(bullets);
                    GetComponent<AudioScript>().PickUpSound();
                    Destroy(thisItem);
                }


            }
            
        }
    }
}
