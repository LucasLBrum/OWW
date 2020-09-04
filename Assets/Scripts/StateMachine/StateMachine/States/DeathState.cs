using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
      public DeathState(string name)
    {
        Name = name;
    }


    public override void Execute()
    {
        base.Execute();
    }

    public void Death(){
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoMorto);
            Game.singleton.deathGameObject.SetActive(true);
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(0,0);
            Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputX", 0f);
            Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputY", 0f);
    }
}
