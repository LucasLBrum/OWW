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
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(0,0);
        }

        Player.singleton.carterScene.GetComponent<PlayerMovement>().All();
        Game.singleton.catavento.Rotate();
        Game.singleton.shootRay.PerformRaycast();
    }
}
