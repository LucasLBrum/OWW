using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MarketInteractable : MonoBehaviour
{
    public ItemResource selectedItem;
    public Text descriptionText;

    void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<CarterStatus>())
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Game.singleton.estadoComprando.EnterState();
            }
        }
    }

    public void ExitMarket()
    {
        Game.singleton.estadoComprando.ExitState();
    }

    public void BuyItem()
    {
        if(selectedItem != null)
        {
            if(Player.singleton.carterScene.inventoryInScene.money >= selectedItem.cost)
            {
                if(Player.singleton.carterScene.inventoryInScene.VerificationSlotsOpen() == true)
                {
                     Player.singleton.carterScene.inventoryInScene.UpdateMoneyText(selectedItem.cost, 2);
                    Player.singleton.carterScene.inventoryInScene.VerificationItem(selectedItem, null);
                    Debug.Log("Comprei");
                }

            }
        }
    }

    public void UpdateDescription(string description)
    {
        descriptionText.text = description;
    }
}
