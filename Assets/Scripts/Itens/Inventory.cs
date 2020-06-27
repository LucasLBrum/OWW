﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public List<Slot> weaponSlot = new List<Slot>();

    public List<ItemResource> itemResources = new List<ItemResource>();
    public List<ItemResource> weaponsResorces = new List<ItemResource>();

    public void VerificationItem(ItemResource newItem, GameObject itemScene)//atraves de um switch verifico o tipo do item e chamo a funcao de adicionar o item à determinada lista.
    {
        switch (newItem.itemType)
        {
            case ItemType.Other:

                VerificationList(newItem, slots, itemScene, itemResources);
                break;

            case ItemType.Consumable:
                VerificationList(newItem, slots, itemScene, itemResources);
                break;

            case ItemType.Equipment:
                VerificationList(newItem, weaponSlot, itemScene, weaponsResorces);
                break;
        }
    }
    public void VerificationList(ItemResource item, List <Slot> list, GameObject ItemScene, List<ItemResource> listItens)
    {
        for (int i = 0; i < list.Count; i++)//verifico a quantidade de itens na lista
        {
            if (list[i].open)//verifico se ha algum slot aberto parao item
            {
                Destroy(ItemScene);
                list[i].AddItem(item);
                listItens.Add(item);
                return;
            }
            else
            {
                //Debug.Log("Nenhum slot diponivel campeão");
            }
        }
    }

}