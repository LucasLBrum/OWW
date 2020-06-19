using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item Asset")]
public class ItemResource : ScriptableObject
{
	public string itemName;
	public string description;
	public int cost;
	public GameObject itemPrefab;
	public Sprite itemSprite;

	public ItemType itemType;

	public Item CreateResourceItem()
	{
		Item resourceItem;

		switch (itemType)
		{
			case ItemType.Other:
				resourceItem = new Other(itemName, cost);
				return resourceItem;

			case ItemType.Consumable:
				resourceItem = new Consumable(itemName, cost);
				return resourceItem;

			case ItemType.Equipment:
				resourceItem = new Equipment(itemName, cost);
				return resourceItem;

		}

		return null;
	}
}
