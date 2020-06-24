using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject item; //item que esta dentro do collider.

    private void OnTriggerStay(Collider other)//enquanto o item estiver dentro do trigger da mão do character
    {
        if(other.tag == "Coletavel") //se tiver a tag "coletavel" o player pode o coletar.
        {
            PickUp(other.gameObject);//função de coleta.
        }
    }

    private void OnTriggerExit(Collider other)//quando a mão estava sem nada por perto o "item" fica vazio.
    {
        item = null;
    }

    void PickUp(GameObject thisItem)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemResource resorce = thisItem.GetComponent<ItemScene>().thisItem;//pega o componenete de itemScene do item que esta na mão.
            Player.singleton.carterScene.inventoryInScene.VerificationItem(resorce,thisItem);//adiciona esse item ao inventario.
        }
    }
}
