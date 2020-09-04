using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : State
{
    public Paused(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Game.singleton.pauseGameObject.SetActive(false);
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
        }
    }

    public void Despause()
    {
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Game.singleton.pauseGameObject.SetActive(false);
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
    }
}
