using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
	protected string itemName; //Nome do item.
	protected int itemCost;//Preço do item.
	protected bool stackable;//é acumulavel ?
	protected int amount;//quantidade
	public Sprite itemSprite;
	public GameObject itemPrefab;

	public ItemType type;//tipo do item

	//construtores
	public string ItemName
	{
		get { return itemName; }
	}

	public int ItemCost
	{
		get { return itemCost; }
	}

}
	public enum ItemType//tipos de itens
	{
		Consumable, Equipment, Other
	}

	//Consumivel
	public class Consumable : Item
	{
		public Consumable(string name, int cost)
		{
			itemName = name;
			itemCost = cost;
			stackable = true;

			type = ItemType.Consumable;
		}
	}

	//Equipamento
	public class Equipment : Item
	{
		public Equipment(string name, int cost)
		{
			itemName = name;
			itemCost = cost;
			stackable = false;

			type = ItemType.Equipment;
		}
	}

	//Objetos unicos como mapas, pedras entre outros.
	public class Other : Item
	{
		public Other(string name, int cost)
		{
			itemName = name;
			itemCost = cost;
			stackable = false;

			type = ItemType.Other;
		}
	}

