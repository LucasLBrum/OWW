using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public EnemyMovement[] enemys;
    public Quest[] quests;
    public ColliderMission colliderMission;
    public Catavento catavento;


    void Start()
    {
        Game.singleton.cameraMain.enabled = true;
        Player.singleton.canvasPlayer.enabled = true;
        Player.singleton.carterScene.transform.position = transform.position;
        Game.singleton.enemys = enemys;
        Game.singleton.estadoJogando.enemys = enemys;
        Player.singleton.questManager.cMission = colliderMission;
        Game.singleton.estadoJogando.catavento = catavento;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);

    }



}
