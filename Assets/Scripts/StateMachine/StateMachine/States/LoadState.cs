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

    public void LoadPlaying()
    {
        Player.singleton.childrens.SetActive(true);
        Player.singleton.meshPlayer.SetActive(true);
        Player.singleton.carterScene.transform.position = new Vector3(43.55f, 6, -24);
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        Player.singleton.carterScene.GetComponent<AudioSource>().enabled = true;

    }
}
