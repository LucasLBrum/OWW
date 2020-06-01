using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    CharacterController player;
    public Transform point = null;
    public Transform point2 = null;
    public Transform cam;
    Animator anim; //Animator presente no player
    //float rotSpeed = 80; //velocidade de rotacao
    float rot; //variavel que vai receber o valor de horizontal
    float speedH = 2.0f;
    float speedV = 2.0f;
    float H = 0.0f;
    float V = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>(); //pegar o animator do player
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
       PMoviment();//chamando a funcao
       PRotateH();
    }
    

    void PMoviment()
    {
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        //run
        if (Input.GetKey(KeyCode.LeftShift))
            anim.SetBool("Run", true); //Segurando o shift esquerdo a bool Run do controle de animação recebe true
        else
            anim.SetBool("Run", false); //Soltando o shift esquerdo a bool Run do controle de animação recebe false
                                        //Lower

        if (Input.GetKey(KeyCode.LeftControl))
          anim.SetBool("Lower", true); //Segurando o Controll esquerdo a bool Lower do controle de animação recebe true
         else
          anim.SetBool("Lower", false); //Soltando o Controll esquerdo a bool Lower do controle de animação recebe false

          //Jump

         if (Input.GetKey(KeyCode.Space))
          anim.SetBool("Jump", true); //Segurando o Space a bool Lower do controle de animação recebe true
         else
          anim.SetBool("Jump", false); //Soltando o Space a bool Lower do controle de animação recebe false

         //Jump Run

         if (Input.GetKey(KeyCode.Space))
          anim.SetBool("JumpStop", true); //Segurando o Space a bool Lower do controle de animação recebe true
         else
          anim.SetBool("JumpStop", false); //Soltando o Space a bool Lower do controle de animação recebe false

        //roll

        if (Input.GetKey(KeyCode.R))
          anim.SetBool("Roll", true); //Segurando o R a bool Lower do controle de animação recebe true
         else
          anim.SetBool("Roll", false); //Soltando o R a bool Lower do controle de animação recebe false

        //Shooting
        if (Input.GetKey(KeyCode.Mouse1))        
            anim.SetBool("Shooting", true); //Segurando o R a bool Lower do controle de animação recebe true                  
        else
            anim.SetBool("Shooting", false); //Soltando o R a bool Lower do controle de animação recebe false

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("Shoot", true); //Segurando o R a bool Lower do controle de animação recebe true

        }
        else
            anim.SetBool("Shoot", false); //Soltando o R a bool Lower do controle de animação recebe false


        gameObject.transform.transform.Rotate(1, 0, 0);
    }

    void PRotateH()
    {
        if (anim.GetBool("Shooting"))
        {
            H += speedH * Input.GetAxis("Mouse X");
            V -= speedV * Input.GetAxis("Mouse Y");
            V = Mathf.Clamp(V, -20f, 20f);
            transform.eulerAngles = new Vector3(V, H, 0.0f);
            cam.position = point.position; 
        }
        else
        {
            H += speedH * Input.GetAxis("Mouse X");
            transform.eulerAngles = new Vector3(0, H, 0.0f);
            cam.position = point2.position;

        }
    }

    void PRotateVH()
    {
        //H = Mathf.Clamp(H, -180f, 180f);       
        V = Mathf.Clamp(V, -20f, 20f);
        //the rotation range

        H += speedH * Input.GetAxis("Mouse X");
        V -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(V, H, 0.0f);
    }

}
