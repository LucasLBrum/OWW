using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    void Start()
    {
        Game.singleton.cameraMain.enabled = true;
        Player.singleton.canvasPlayer.enabled = true;
        Player.singleton.carterScene.transform.position = transform.position;
    }
}
