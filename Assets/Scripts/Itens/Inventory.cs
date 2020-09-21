using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryObject;
    public Sprite noneImage;
    public List<Slot> slots = new List<Slot>();
    public List<Slot> weaponSlot = new List<Slot>();
    public List<ItemResource> itemResources = new List<ItemResource>();
    public List<ItemResource> weaponsResorces = new List<ItemResource>();
    public Munition munitionL;
    public Munition munitionB;
    public WeaponInScene atualWeapon;
    public float money;
    public Text munition;
    public Text moneyText;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        UpdateMoneyText(100, 1);
    }
    public void UpdateMoneyText(float value, int op)
    {
        if(op == 1)
        {
            money += value;
            moneyText.text = money.ToString() + "$";
        }
        else
        {
            money -= value;
            moneyText.text = money.ToString() + "$";
        }
    }
    public void UpdateMunitionText()
    {
        munition.text = atualWeapon.bullets.ToString() + "/" + atualWeapon.bulletsMax.ToString();
    }
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
            if (list[i].open)//verifico se ha algum slot aberto para o item
            {
                if(listItens == weaponsResorces)
                {
                    if(ItemScene == null)
                    {
                        ItemScene = item.itemPrefab;
                    }
                    list[i].GetComponent<WeaponInScene>().GetDetailsWeapon(list[i].GetComponent<WeaponInScene>(), ItemScene.GetComponent<WeaponInScene>());
                    if(ItemScene != null)
                    Destroy(ItemScene);
                    list[i].AddItem(item);
                    listItens.Add(item);
                    return;
                }
                else
                {
                    Destroy(ItemScene);
                    list[i].AddItem(item);
                    listItens.Add(item);
                    return;
                }
            }
            else
            {
                
            }
        }
        Debug.Log("sem slots");
    }
    public bool VerificationSlotsOpen(List<Slot> slotTemp)
    {
        for (int i = 0; i < slotTemp.Count; i++)//verifico a quantidade de itens na lista
        {
            if(slotTemp[i].open)
            {
                return true;
            }
        }
        return false;
    }
}