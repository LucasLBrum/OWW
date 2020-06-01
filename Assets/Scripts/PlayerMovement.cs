using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Animator anim;
    public Rig rig;
    Vector2 input;
    public CinemachineCameraOffset m_cineMachineOffSetsConfigs; //classe que controla a posicao da FreeLock camera do cinemachine.
    public RaycastWeapon weapon;

    float aimDuration = 0.3f;

    private void Awake()
    {
        weapon = GetComponentInChildren<RaycastWeapon>();
        anim = GetComponent<Animator>();//pegar componente desse objeto.
    }
    private void Update()
    {
        input.x = Input.GetAxis("Horizontal"); //recebe o valor dos parametros da unity de horizontal e vertical.
        input.y = Input.GetAxis("Vertical");

        anim.SetFloat("InputX", input.x);
        anim.SetFloat("InputY", input.y); //"conecta" as variaveis do script aos paramentros do animator.


        if (Input.GetKey(KeyCode.LeftControl))
            anim.SetBool("Lower", true); //Segurando o Controll esquerdo a bool Lower do controle de animação recebe true
        else
            anim.SetBool("Lower", false); //Soltando o Controll esquerdo a bool Lower do controle de animação recebe false

        if (Input.GetMouseButton(1))
        {
            rig.weight += Time.deltaTime / aimDuration;
            m_cineMachineOffSetsConfigs.m_Offset = new Vector3(0.38f, -0.15f, 1);
        }
        else
        {
            m_cineMachineOffSetsConfigs.m_Offset = new Vector3(0.38f, -0.15f, -0.9f);
            rig.weight -= Time.deltaTime / aimDuration;
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.StartFire();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            weapon.StopFire();
        }
    }
}
