﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    Animator anim; //componente de animação.
    public Rig rig;//componente de Rig 
    Vector2 input;//input para ser usado na movimentação
    public CinemachineCameraOffset m_cineMachineOffSetsConfigs; //classe que controla a posicao da FreeLock camera do cinemachine.
    public GameObject imagePanel;//inventario
    bool away = false;// o jogador esta com o inventario aberto?

    public float turnSpeed = 15; //velocidade de rotacao da yawcamera
    public Cinemachine.CinemachineFreeLook cinemachine_m; //componente de cinemachine
    Camera mainCamera; //main camera
    public ActiveWeapon activeWeapon;

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
    }

    void CharacterMoviment() 
    {
        if (away == false)
        {
            input.x = Input.GetAxis("Horizontal"); //recebe o valor dos parametros da unity de horizontal e vertical.
            input.y = Input.GetAxis("Vertical");

            anim.SetFloat("InputX", input.x);
            anim.SetFloat("InputY", input.y); //"conecta" as variaveis do script aos paramentros do animator.


            if (Input.GetKey(KeyCode.LeftControl))
                anim.SetBool("Lower", true); //Segurando o Controll esquerdo a bool Lower do controle de animação recebe true
            else
                anim.SetBool("Lower", false); //Soltando o Controll esquerdo a bool Lower do controle de animação recebe false

            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Jump", true);
            }
            else
            {
                anim.SetBool("Jump", false);
            }

            if (rig)
            {
                rig.weight = 1.0f;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
            }
        }
    }

    void CharacterView()
    {
        
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; // Ainda nao entendi o codigo.
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
        //activeWeapon.Equip(other.gameObject.GetComponent<WeaponRaycast>());
    }
}
