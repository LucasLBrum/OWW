using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlotMarket : MonoBehaviour
{
    public ItemResource item;

    public Text priceText;

    public MarketInteractable market;
    public Image sprite;

    void Start()
    {
        sprite.sprite = item.itemSprite;
        priceText.text = item.cost.ToString();
    }

    public void PassInformation()
    {
        market.selectedItem = item;
        market.UpdateDescription(item.description);
    }
}
