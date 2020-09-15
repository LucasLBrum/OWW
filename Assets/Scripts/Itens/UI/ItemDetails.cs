using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemDetails : MonoBehaviour
{
    public Slot slot;
    public Text detailsText;

    public void GetDetails()
    {
        transform.position = Input.mousePosition; //pega
    }
    public void DeleteItem()
    {
        if(slot != null)
        slot.RemoveItem();
    }

    public void GetSlotDetails(Slot newSlot)
    {
        slot = newSlot;
        if(slot.item != null)
        {
            gameObject.SetActive(true);
            detailsText.text = slot.item.description;
        }

    }

    public void UseItem()
    {
        if(slot != null)
        slot.UseItem();
    }
}
