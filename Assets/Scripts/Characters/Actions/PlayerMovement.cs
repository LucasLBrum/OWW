using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim; //componente de animação.
    Vector2 input;//input para ser usado na movimentação
    public CinemachineCameraOffset m_cineMachineOffSetsConfigs; //classe que controla a posicao da FreeLock camera do cinemachine.
    public GameObject imagePanel;//inventario
    public GameObject LookCamera;//inventario
    bool away = false;// o jogador esta com o inventario aberto?

    private float turnSpeed = 10; //velocidade de rotacao da yawcamera
    public Cinemachine.CinemachineFreeLook cinemachine_m; //componente de cinemachine
    Camera mainCamera; //main camera
    public ActiveWeapon activeWeapon;
    public Slot slotWeaponUse;

    private void Awake()
    {
        anim = GetComponent<Animator>();//pegar componente desse objeto.
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = Camera.main; //colocando a man camera na referencia

        cinemachine_m.m_XAxis.m_InvertInput = false; //deixando o InvertInput false, poderia ter feito pelo Inspector mas estava bugado, acredito que seja por conta do componente ainda estar em testes.
        cinemachine_m.m_YAxis.m_InvertInput = true;
    }
    private void Update() 
    {
        CharacterMoviment();
        CharacterView();
        OpenInventory();
        EquipWeapon();
    }

    void CharacterMoviment() 
    {
        if (away == false)
        {
            input.x = Input.GetAxisRaw("Horizontal"); //recebe o valor dos parametros da unity de horizontal e vertical.
            input.y = Input.GetAxisRaw("Vertical");

            anim.SetFloat("InputX", input.x, 0.2f, Time.deltaTime);
            anim.SetFloat("InputY", input.y, 0.2f, Time.deltaTime);

            if(slotWeaponUse == null)
            {
                if (Input.GetKey(KeyCode.S) == false)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        anim.SetTrigger("Roll");
                    }
                }
            }


            if (Input.GetKey(KeyCode.Mouse1))
            {
                cinemachine_m.Follow = LookCamera.transform;
            }
            else
            {
                cinemachine_m.Follow = gameObject.transform;
            }


            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!activeWeapon.rigController.GetBool("Holster"))
                {
                    activeWeapon.rigController.SetBool("Holster", true);
                }
                else
                {
                    activeWeapon.rigController.SetBool("Holster", false);
                }
            }
        }
    }

    void CharacterView()
    {
        
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
        
    }

    void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (away)
            {
                away = false;
                //panelIn.SetActive(false);
                imagePanel.SetActive(false);
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                away = true;
                //panelIn.SetActive(true);
                imagePanel.SetActive(true);
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    void EquipWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].open == false)
            {
                if(slotWeaponUse != null)
                {
                    if (Player.singleton.carterScene.inventoryInScene.weaponSlot[0].item == slotWeaponUse.item)
                    {
                        return;
                    }
                }

                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].item);
                slotWeaponUse = Player.singleton.carterScene.inventoryInScene.weaponSlot[0];
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Player.singleton.carterScene.inventoryInScene.weaponSlot[1].open == false)
            {
                if (slotWeaponUse != null)
                {
                    if (Player.singleton.carterScene.inventoryInScene.weaponSlot[1].item == slotWeaponUse.item)
                    {
                        return;
                    }
                }

                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(Player.singleton.carterScene.inventoryInScene.weaponSlot[1].item);
                slotWeaponUse = Player.singleton.carterScene.inventoryInScene.weaponSlot[1];
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (activeWeapon.weapon != null)
            {
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                slotWeaponUse = null;
                activeWeapon.handIK.weight = 0;
                activeWeapon.rigController.Play("Default");
            }
        }

    }


    public void Desequip()
    {
        if(slotWeaponUse != null)
        {
            if (activeWeapon.weaponObject.GetComponent<ItemScene>().thisItem == slotWeaponUse.item)
            {
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                slotWeaponUse = null;
                activeWeapon.handIK.weight = 0;
                activeWeapon.rigController.Play("Default");
            }
        }
    }
}

