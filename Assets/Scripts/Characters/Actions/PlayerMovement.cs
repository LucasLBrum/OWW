using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject imagePanel = null;//inventario.
    Animator anim; //componente de animação.
    Vector2 input;//input para ser usado na movimentação.
    Camera mainCamera; //main camera
    ActiveWeapon activeWeapon;
    public Slot slotWeaponUse;

    private void Awake()
    {
        activeWeapon = GetComponent<ActiveWeapon>();
        anim = GetComponent<Animator>();//pegar componente desse objeto.
        mainCamera = Camera.main; //colocando a man camera na referencia.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() 
    {
        CharacterMoviment();
        CharacterView();
        OpenInventory();
        EquipWeapon();
        Drop();
    }
    void CharacterMoviment() 
    {

            input.x = Input.GetAxisRaw("Horizontal"); //recebe o valor dos parametros da unity de horizontal e vertical.
            input.y = Input.GetAxisRaw("Vertical");

            anim.SetFloat("InputX", input.x, 0.2f, Time.deltaTime);
            anim.SetFloat("InputY", input.y, 0.2f, Time.deltaTime);


            if (Input.GetKey(KeyCode.S) == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetTrigger("Roll");
                }
            }

            if (Input.GetKey(KeyCode.S) == false)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    GuardarArma();
                    anim.SetBool("Running", true);
                }
                else
                {
                    anim.SetBool("Running", false);
                }   
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (activeWeapon.rigController.GetBool("Take") == true)
                {
                    activeWeapon.rigController.SetBool("Take", false);
                }
                else
                {
                    activeWeapon.rigController.SetBool("Take", true);
                }
            }

    }
    void CharacterView()
    {
        float turnSpeed = 10;
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
    void OpenInventory()//Abrir o Inventário.
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (imagePanel.activeSelf == true)
            {
                imagePanel.SetActive(false);
                UnityEngine.Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                imagePanel.SetActive(true);
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }
    void EquipWeapon()//Acessar os slots de armas do inventário.
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
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].item);
                slotWeaponUse = Player.singleton.carterScene.inventoryInScene.weaponSlot[0];
            }
        }//Acessar slot 1.
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
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(Player.singleton.carterScene.inventoryInScene.weaponSlot[1].item);
                slotWeaponUse = Player.singleton.carterScene.inventoryInScene.weaponSlot[1];
            }

        }//Acessar slot 2.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (activeWeapon.weapon != null)
            {
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                slotWeaponUse = null;
                activeWeapon.handIK.weight = 0;
                activeWeapon.rigController.Play("Default");
            }
        }//Ficar com as mãos nuas.

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
    public void Drop()
    {
        if(slotWeaponUse != null)
        {
            if (Input.GetKeyDown(KeyCode.G)) //Deseqipar item.
            {
                slotWeaponUse.RemoveItem();
            }
        }
    }
    public void GuardarArma()
    {
        activeWeapon.rigController.SetBool("Take", true);
    }
    public void SacarArma()
    {
        activeWeapon.rigController.SetBool("Take", false);
    }
}

