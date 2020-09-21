using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketState : State
{
     public MarketState(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();

    }

    public override void EnterState()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoComprando);
        Game.singleton.marketPanel.SetActive(true);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(0,0);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputX", 0f);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputY", 0f);
    }

    public override void ExitState()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Game.singleton.marketPanel.SetActive(false);
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
    }
}
