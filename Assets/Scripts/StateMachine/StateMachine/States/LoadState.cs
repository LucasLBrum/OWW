using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadState : State
{
    public LoadState(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void ExitState()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
    }

    public override void EnterState()
    {
        Player.singleton.canvasPlayer.enabled = false;
        Game.singleton.cameraMain.enabled = false;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.loadState);
    }
}
