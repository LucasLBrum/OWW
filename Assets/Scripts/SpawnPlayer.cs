using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    void Start()
    {
        Player.singleton.c.enabled = true;
        Player.singleton.canvasPlayer.enabled = true;
        Player.singleton.carterScene.transform.position = transform.position;
    }
}
