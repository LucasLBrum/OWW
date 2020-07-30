﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game singleton { get; private set; }
    
    public StateMachine m_StateMachine = new StateMachine();

    //Estados do sistema

    public Navigation estadoNavegacao;
    public Playing estadoJogando;
    public Paused estadoPausado;

    private void Awake()
    {
        if(singleton != this && singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        estadoNavegacao = new Navigation("Navegação");
        estadoJogando = new Playing("Jogando");
        estadoPausado = new Paused("Pausado");

        m_StateMachine.ChangeState(estadoNavegacao);
    }

    // Update is called once per frame
    void Update()
    {
        m_StateMachine.RunState();
    }
}