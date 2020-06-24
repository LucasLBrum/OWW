using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public List<Slot> weaponSlot = new List<Slot>();
    public Button button;
    RaycastHit2D hit;

    public List<ItemResource> itemResources = new List<ItemResource>();

    public void VerificationItem(ItemResource newItem, GameObject itemScene)//atraves de um switch verifico o tipo do item e chamo a funcao de adicionar o item à determinada lista.
    {
        switch (newItem.itemType)
        {
            case ItemType.Other:

                AddItem(newItem, slots, itemScene);
                Debug.Log("é um item");
                break;

            case ItemType.Consumable:
                AddItem(newItem, slots, itemScene);
                Debug.Log("é um item");
                break;

            case ItemType.Equipment:
                AddItem(newItem, weaponSlot, itemScene);
                Debug.Log("é um equipamento");
                break;
        }
    }
    public void AddItem(ItemResource item, List <Slot> list, GameObject ItemScene)
    {
        for (int i = 0; i < list.Count; i++)//verifico a quantidade de itens na lista
        {
            if (list[i].open)//verifico se ha algum slot aberto parao item
            {
                Destroy(ItemScene);
                list[i].open = false;
                list[i].itemImage.sprite = item.itemSprite;
                list[i].item = item;
                itemResources.Add(item);
                return;
            }
            else
            {
                Debug.Log("Nenhum slot diponivel campeão");
            }
        }
    }
}