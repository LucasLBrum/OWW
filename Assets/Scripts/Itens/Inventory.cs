using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // public Slot[] slots = new Slot[12];
    public List<Slot> slots = new List<Slot>();
    public GameObject inventory;

    public List<ItemResource> itemResources = new List<ItemResource>();

    private void Awake()
    {


    }


    public void AddItem(ItemResource item)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].open)
            {
                slots[i].open = false;
                slots[i].itemImage.sprite = item.itemSprite;
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