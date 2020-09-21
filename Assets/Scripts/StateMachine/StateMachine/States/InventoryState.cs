using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryState : State
{
    public InventoryState(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ExitState();
        }
    }

    public override void EnterState()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.inventoryState);
        Game.singleton.inventory.inventoryObject.SetActive(true);
        Game.singleton.estadoJogando.movement.StopCamera(0,0);
        Game.singleton.estadoJogando.movement.GetComponent<Animator>().SetFloat("InputX", 0f);
        Game.singleton.estadoJogando.movement.GetComponent<Animator>().SetFloat("InputY", 0f);
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
    }

    public override void ExitState()
    {
        
        Game.singleton.inventory.inventoryObject.SetActive(false);
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
    }
}
