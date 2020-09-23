using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playing : State
{
    public Playing(string name)
    {
        Name = name;
    }

    public CarterScene carter = Player.singleton.carterScene;
    public PlayerMovement movement = Player.singleton.carterScene.GetComponent<PlayerMovement>();
    public ShootRaycast shootRay = Game.singleton.shootRay;
    public Catavento catavento = Game.singleton.catavento;
    public ShootProject weaponShoot;
    public EnemyMovement[] enemys;



    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.singleton.estadoPausado.EnterState();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Game.singleton.inventoryState.EnterState();
        }

        movement.EquipWeapon();
        movement.CharacterView();
        movement.Drop();
        movement.CharacterMovement();
        movement.GuardarArma();
        if(Game.singleton.catavento != null)
        catavento.Rotate();
        shootRay.PerformRaycast();
        if(weaponShoot != null)
        {
            weaponShoot.Shoot();
            weaponShoot.Reaload();
            if(Input.GetKey(KeyCode.Mouse1))
            {
                if(weaponShoot.loadingPower == false)
                weaponShoot.StartCoroutine(weaponShoot.SuperShoot());
            }
        }
    }

    public override void EnterState()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Game.singleton.pauseGameObject.SetActive(false);
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoJogando);
        Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(2, 300);
        if(enemys != null)
        {
            for (int i = 0; i < enemys.Length; i++)
            {
                if(enemys[i].inBattle == true)
                {
                    Debug.Log("para poha");
                    if(enemys[i].inBattle == true)
                    enemys[i].StartCoroutine(enemys[i].chaseC);
                }
            }
        }
    }
}
