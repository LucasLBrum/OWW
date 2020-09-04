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
            Game.singleton.inventory.inventoryObject.SetActive(false);
            UnityEngine.Cursor.visible = false;
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
        }
    }
}
