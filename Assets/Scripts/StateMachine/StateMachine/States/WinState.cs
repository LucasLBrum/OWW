using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : State
{
    public WinState(string name)
    {
        Name = name;
    }


    public override void Execute()
    {
        base.Execute();

        
    }

    public override void EnterState()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoFim);
        Game.singleton.winPanel.SetActive(true);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputX", 0f);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputY", 0f);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(true);
        for (int i = 0; i < Game.singleton.enemys.Length; i++)
        {
            Game.singleton.enemys[i].gameObject.SetActive(false);
        }

    }
}
