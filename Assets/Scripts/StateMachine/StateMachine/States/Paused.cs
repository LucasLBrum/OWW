using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : State
{
    EnemyMovement[] enemys;

    public Paused(string name)
    {
        Name = name;
    }

    public override void Execute()
    {
        base.Execute();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.singleton.estadoJogando.EnterState();
        }
    }

    public override void ExitState()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Game.singleton.pauseGameObject.SetActive(false);
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
    }

    public override void EnterState()
    {
        enemys = Game.singleton.enemys;
        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoPausado);
        Game.singleton.pauseGameObject.SetActive(true);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(0,0);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputX", 0f);
        Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputY", 0f);
        
        for (int i = 0; i < enemys.Length; i++)
        {
            if(enemys[i].inBattle == true)
            {
                Debug.Log("para poha");
                //enemys[i].StopCoroutine(enemys[i].chaseC);
                enemys[i].StopAllCoroutines();
                enemys[i].StopEnemy();
            }
        }
    }
}
