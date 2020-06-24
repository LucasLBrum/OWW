using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScene : Interactable
{
    public ItemResource thisItem;

    private void Start()
    {
        collectable = true;
    }
}
