using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public BattleRange[] camps;
    void Start()
    {
        Game.singleton.estadoJogando.EnterState();
        Game.singleton.cameraMain.enabled = true;
        Player.singleton.canvasPlayer.enabled = true;
        Player.singleton.carterScene.transform.position = transform.position;
    }
}
