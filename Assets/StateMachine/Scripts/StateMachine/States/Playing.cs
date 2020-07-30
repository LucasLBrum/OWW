using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : State
{
    public Playing(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoPausado);
        }
    }
}
