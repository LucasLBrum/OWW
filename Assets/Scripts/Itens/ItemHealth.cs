using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public float healthpower;

    public void Healthitem()
    {
        Player.singleton.carterScene.carter.TakeLife(Player.singleton.carterScene.carter, healthpower, 2);
    }
}
