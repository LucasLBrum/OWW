﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioSource source;
    
    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = GameConfig.singleton.volumeAudios;
        source.Play();
        float distance = Vector3.Distance(transform.position, Player.singleton.carterScene.transform.position);//a variável "distance", agora recebe a distancia entre o agente e o player.
        if(distance < 3.5)
        {
            Player.singleton.carterScene.carter.TakeLife(Player.singleton.carterScene.carter, 25, 1);
        }
        Destroy(gameObject, 1);
    }
}
