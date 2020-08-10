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
                ItemResource resorce = thisItem.GetComponent<ItemScene>().thisItem;//refêrencia do item do raycast
                Player.singleton.carterScene.inventoryInScene.VerificationItem(resorce, thisItem);//adiciona esse item ao inventario.
            }
            else if(thisItem.GetComponent<Munition>() != null)
            {
                int bullets = thisItem.GetComponent<Munition>().boxMunition;
                if (thisItem.GetComponent<Munition>().type == MunitionType.Big)
                {
                    Player.singleton.carterScene.inventoryInScene.munitionB.AddMunition(bullets);
                    Destroy(thisItem);
                }
                else if(thisItem.GetComponent<Munition>().type == MunitionType.Little)
                {
                    Player.singleton.carterScene.inventoryInScene.munitionL.AddMunition(bullets);
                    Destroy(thisItem);
                }


            }
            
        }
    }
}
