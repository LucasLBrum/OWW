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
            var prefab = Instantiate(item.itemPrefab, characterTranform.position, transform.rotation);
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
}
