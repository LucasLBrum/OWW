using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    public static Game singleton;
    public PlayerMovement movement;
    public Catavento catavento;
    public ShootRaycast shootRay;
    public StateMachine m_StateMachine = new StateMachine();

    public Inventory inventory;
    public GameObject pauseGameObject;
    public GameObject deathGameObject;
    public Camera cameraMain;
    public ShootProject weapon;
    public GameObject marketPanel;
    public GameObject boxTalk;
    public Text talkText;
    public EnemyMovement[] enemys;
    public GameObject winPanel;


    //Estados do sistema

    public Playing estadoJogando;
    public Paused estadoPausado;
    public InventoryState inventoryState;
    public DeathState estadoMorto;
    public LoadState loadState;
    public TalkingState estadoFalando;
    public MarketState estadoComprando;
    public WinState estadoFim;
    public Cutscene EstadoCutscene;


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
        estadoJogando = new Playing("Jogando");
        estadoFim = new WinState("ganhou");
        EstadoCutscene = new Cutscene("cutscene");
        estadoPausado = new Paused("Pausado");
        inventoryState = new InventoryState("Inventario Aberto");
        loadState = new LoadState("carregando");
        estadoMorto = new DeathState("morto");
        estadoFalando = new TalkingState("falando");
        estadoComprando = new MarketState("Comprando");

        estadoJogando.enemys = enemys;

        movement = Player.singleton.carterScene.GetComponent<PlayerMovement>();
        estadoJogando.movement = movement;
        EstadoCutscene.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        m_StateMachine.RunState();
    }
}
