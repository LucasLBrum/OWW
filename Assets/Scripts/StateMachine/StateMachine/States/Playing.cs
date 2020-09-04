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


    public override void Execute()
    {
        base.Execute();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.estadoPausado);
            Game.singleton.pauseGameObject.SetActive(true);
            Player.singleton.carterScene.GetComponent<PlayerMovement>().StopCamera(0,0);
            Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputX", 0f);
            Player.singleton.carterScene.GetComponent<Animator>().SetFloat("InputY", 0f);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Game.singleton.m_StateMachine.ChangeState(Game.singleton.inventoryState);
            Game.singleton.inventory.inventoryObject.SetActive(true);
            movement.StopCamera(0,0);
            movement.GetComponent<Animator>().SetFloat("InputX", 0f);
            movement.GetComponent<Animator>().SetFloat("InputY", 0f);
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        }

        movement.All();
        if(Game.singleton.catavento != null)
        catavento.Rotate();
        shootRay.PerformRaycast();
        if(weaponShoot != null)
        {
            weaponShoot.Shoot();
            weaponShoot.Reaload();

        }
    }

    public void inLoad()
    {
        Game.singleton.m_StateMachine.ChangeState(Game.singleton.loadState);
        carter.transform.position = new Vector3(43.55f, 6, -24);
        Player.singleton.childrens.SetActive(false);
        Player.singleton.carterScene.GetComponent<AudioSource>().enabled = false;
        Player.singleton.meshPlayer.SetActive(false);

    }
}
