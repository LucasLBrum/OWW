using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : State
{
    public Cutscene(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();
    }
    public override void EnterState()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.EstadoCutscene);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }
}
