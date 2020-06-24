using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool open = true;
    public Image itemImage;
    public ItemResource item;
    public Sprite nothing;



    public void RemoveItem()
    {
        if (!open)
        {
            open = true;
            itemImage.sprite = nothing;
            item = null;
        }
    }
}
