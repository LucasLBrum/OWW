using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject item; //item que esta dentro do collider.

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Coletavel") 
        {
            item = other.gameObject;
            PickUp(item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        item = null;
    }

    void PickUp(GameObject thisItem)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ItemResource resorce = thisItem.GetComponent<ItemScene>().thisItem;
            Player.singleton.carterScene.inventoryInScene.AddItem(resorce);

            thisItem.SetActive(false);
        }
    }
}
