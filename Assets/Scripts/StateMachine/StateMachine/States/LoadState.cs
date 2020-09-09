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
        //Player.singleton.childrens.SetActive(true);
        //Player.singleton.meshPlayer.SetActive(true);
        //Player.singleton.carterScene.GetComponent<AudioSource>().enabled = true;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
    }

    public void inLoad()
    {
        Player.singleton.canvasPlayer.enabled = false;
        Player.singleton.c.enabled = false;
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.loadState);
        //Player.singleton.childrens.SetActive(false);
        //Player.singleton.carterScene.GetComponent<AudioSource>().enabled = false;
        //Player.singleton.meshPlayer.SetActive(false);
    }
}
