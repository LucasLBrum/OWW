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
            ItemResource resorce = thisItem.GetComponent<ItemScene>().thisItem;//pega o componenete de itemScene do item que esta na mão.
            Player.singleton.carterScene.inventoryInScene.VerificationItem(resorce,thisItem);//adiciona esse item ao inventario.
        }
    }
}
