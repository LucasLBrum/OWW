using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game singleton;

    public Catavento catavento;
    public ShootRaycast shootRay;
    public StateMachine m_StateMachine = new StateMachine();

    public Inventory inventory;
    public GameObject pauseGameObject;
    public GameObject deathGameObject;

    public ShootProject weapon;



    //Estados do sistema

    public Navigation estadoNavegacao;
    public Playing estadoJogando;
    public Paused estadoPausado;
    public InventoryState inventoryState;
    public DeathState estadoMorto;
    public LoadState loadState;
    public TalkingState estadoFalando;


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
        inventoryState = new InventoryState("Inventario Aberto");
        loadState = new LoadState("carregando");
        estadoMorto = new DeathState("morto");
        estadoFalando = new TalkingState("falando");


        m_StateMachine.ChangeState(estadoJogando);
    }

    // Update is called once per frame
    void Update()
    {
        m_StateMachine.RunState();
    }

    public void Despause()
    {
        estadoPausado.Despause();
    }
}
