using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MarketInteractable : MonoBehaviour
{
    public ItemResource selectedItem;
    public Text descriptionText;


    public void ExitMarket()
    {
        Game.singleton.estadoComprando.ExitState();
    }

    public void BuyItem()
    {
        if(selectedItem != null)
        {
            if(selectedItem.itemType == ItemType.Consumable || selectedItem.itemType == ItemType.Other)
            {
                if(Player.singleton.carterScene.inventoryInScene.money >= selectedItem.cost)
                {
                    if(Player.singleton.carterScene.inventoryInScene.VerificationSlotsOpen(Player.singleton.carterScene.inventoryInScene.slots) == true)
                    {
                        Player.singleton.carterScene.inventoryInScene.UpdateMoneyText(selectedItem.cost, 2);
                        Player.singleton.carterScene.inventoryInScene.VerificationItem(selectedItem, null);
                        Debug.Log("Comprei");
                    }

                }
            }
            else
            {
                if(Player.singleton.carterScene.inventoryInScene.money >= selectedItem.cost)
                {
                    if(Player.singleton.carterScene.inventoryInScene.VerificationSlotsOpen(Player.singleton.carterScene.inventoryInScene.weaponSlot) == true)
                    {
                        Player.singleton.carterScene.inventoryInScene.UpdateMoneyText(selectedItem.cost, 2);
                        Player.singleton.carterScene.inventoryInScene.VerificationItem(selectedItem, null);
                        Debug.Log("Comprei");
                    }

                }
            }
            
        }
    }

    public void UpdateDescription(string description)
    {
        descriptionText.text = description;
    }
}
