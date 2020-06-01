using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public float turnSpeed = 15; //velocidade de rotacao da yawcamera

    public Cinemachine.CinemachineFreeLook cinemachine_m; //componente de cinemachine

    Camera mainCamera; //main camera

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
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; // Ainda nao entendi o codigo.
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
}
