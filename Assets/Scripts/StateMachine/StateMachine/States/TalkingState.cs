﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingState : State
{
    public TalkingState(string name)
    {
        Name = name;
    }


    public override void Execute()
    {
        base.Execute();

        
    }
    public override void EnterState()
    {
        Game.singleton.boxTalk.SetActive(true);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoFalando);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(0,0);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputX", 0f);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputY", 0f);
    }

    public override void ExitState()
    {
        Game.singleton.boxTalk.SetActive(false);
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
    }
}
