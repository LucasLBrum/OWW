using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : State
{
    public Navigation(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        }
    }
}
