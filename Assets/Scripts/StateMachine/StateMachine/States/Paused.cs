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
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoPausado);
        }
        */
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
        }
    }
}
