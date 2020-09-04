using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool open = true; //Há algum item no slot?
    public Image itemImage;//Componente de Imagem do slot
    public ItemResource item;//Componente de "ItemResource", que vai abrigar o item que o character recolher.
    public Sprite nothing;//Sprite padrão da Imagem.
    public ItemDetails itemDetails;//Objeto que mostra os detalhes e as possiveis ações do item.

    public Transform characterTranform;

    public void RemoveItem()
    {
        if (!open)
        {
            if(Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse != null)
            {
                if (Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse.item == this.item)
                {
                    Player.singleton.carterScene.GetComponent<PlayerMovement>().Desequip();
                }

            }
            var prefab = Instantiate(item.itemPrefab, characterTranform.position, transform.rotation);
            prefab.gameObject.GetComponent<BoxCollider>().enabled = true;
            prefab.gameObject.GetComponent<Rigidbody>().useGravity = true;
            prefab.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            if(GetComponent<WeaponInScene>() != null)
            {
                prefab.GetComponent<WeaponInScene>().GetDetailsWeapon(prefab.GetComponent<WeaponInScene>(), GetComponent<WeaponInScene>());
            }

            open = true;
            itemImage.sprite = nothing;
            item = null;
        }
    }
    public void AddItem(ItemResource resource)
    {
        item = resource;
        itemImage.sprite = resource.itemSprite;
        open = false;
    }
   
    public void ReturnInformation()
    {
        itemDetails.GetSlotDetails(this);
    }

    public void UseItem()
    {
        if(item.itemPrefab.GetComponent<ItemHealth>() != null)
        {
            item.itemPrefab.GetComponent<ItemHealth>().Healthitem();
            DeleteItem();
        }
    }

     public void DeleteItem()
    {
        if (!open)
        {
            if(Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse != null)
            {
                if (Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse.item == this.item)
                {
                    Player.singleton.carterScene.GetComponent<PlayerMovement>().Desequip();
                }
            }

            open = true;
            itemImage.sprite = nothing;
            item = null;
        }
    }
}
