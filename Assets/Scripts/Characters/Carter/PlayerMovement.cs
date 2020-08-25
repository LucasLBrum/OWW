using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    GameObject imagePanel = null;//inventario.
    Animator anim; //componente de animação.
    Vector2 input;//input para ser usado na movimentação.
    Camera mainCamera; //main camera
    public CinemachineFreeLook freeLookCamera;//componente da cinemachine 

    public ActiveWeapon activeWeapon;//componente que contem as refêrencias do rig do jogador.

    public Slot slotWeaponUse;//a arma que esta sendo usada atualmente 

    private void Awake()
    {
        activeWeapon = GetComponent<ActiveWeapon>();
        anim = GetComponent<Animator>();//pegar componente desse objeto.
        mainCamera = Camera.main; //colocando a man camera na referencia.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
                    if (Player.singleton.carterScene.carter.stamina > 5)
                    {
                        Player.singleton.carterScene.carter.TakeStamina(5, 1);
                        //Debug.Log(Player.singleton.carterScene.carter.stamina);
                        Player.singleton.carterScene.carterStatus.UpdateUI(Player.singleton.carterScene.carter.stamina, Player.singleton.carterScene.carter.staminaFull, Player.singleton.carterScene.carterStatus.staminaImage);
                        anim.SetTrigger("Roll");
                        if(Player.singleton.carterScene.carterStatus.regen == false)
                        {
                            StartCoroutine(Player.singleton.carterScene.carterStatus.RegenStamina(2, 2));
                        }
                    }
                }
            }

            if (Input.GetKey(KeyCode.S) == false)
            {
                if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Run());
            }

            if (Input.GetKeyDown(KeyCode.Q))
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
                if (slotWeaponUse == Player.singleton.carterScene.inventoryInScene.weaponSlot[1])
                {
                    activeWeapon.weapon.GetDetailsWeapon(Player.singleton.carterScene.inventoryInScene.weaponSlot[1].GetComponent<WeaponInScene>(), activeWeapon.weapon);
                }
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].item, Player.singleton.carterScene.inventoryInScene.weaponSlot[0].GetComponent<WeaponInScene>());
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
                if(slotWeaponUse == Player.singleton.carterScene.inventoryInScene.weaponSlot[0])
                {
                    activeWeapon.weapon.GetDetailsWeapon(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].GetComponent<WeaponInScene>(), activeWeapon.weapon);
                }
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(Player.singleton.carterScene.inventoryInScene.weaponSlot[1].item, Player.singleton.carterScene.inventoryInScene.weaponSlot[1].GetComponent<WeaponInScene>());
                slotWeaponUse = Player.singleton.carterScene.inventoryInScene.weaponSlot[1];
            }

        }//Acessar slot 2.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (activeWeapon.weapon != null)
            {
                if(slotWeaponUse.item == Player.singleton.carterScene.inventoryInScene.weaponSlot[0].item)
                {
                    activeWeapon.weapon.GetDetailsWeapon(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].GetComponent<WeaponInScene>(),activeWeapon.weapon);
                }
                else if(slotWeaponUse.item == Player.singleton.carterScene.inventoryInScene.weaponSlot[1].item)
                {
                    activeWeapon.weapon.GetDetailsWeapon(Player.singleton.carterScene.inventoryInScene.weaponSlot[1].GetComponent<WeaponInScene>(), activeWeapon.weapon);
                }
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
            if (slotWeaponUse.item == Player.singleton.carterScene.inventoryInScene.weaponSlot[0].item)
            {
                activeWeapon.weapon.GetDetailsWeapon(Player.singleton.carterScene.inventoryInScene.weaponSlot[0].GetComponent<WeaponInScene>(), activeWeapon.weapon);
            }
            else if (slotWeaponUse.item == Player.singleton.carterScene.inventoryInScene.weaponSlot[1].item)
            {
                activeWeapon.weapon.GetDetailsWeapon(Player.singleton.carterScene.inventoryInScene.weaponSlot[1].GetComponent<WeaponInScene>(), activeWeapon.weapon);
            }

            if (activeWeapon.weaponObject.GetComponent<ItemScene>().thisItem == slotWeaponUse.item)
            {
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                slotWeaponUse = null;
                activeWeapon.handIK.weight = 0;
                activeWeapon.rigController.Play("Default");
            }
        }
    }//desequipa a arma, caso esteja em suas mãos.
    public void Drop()
    {
        if(slotWeaponUse != null)
        {
            if (Input.GetKeyDown(KeyCode.G)) //Deseqipar item.
            {
                slotWeaponUse.RemoveItem();
            }
        }
    }//derruba a arma caso esteja em suas mãos.
    public void GuardarArma()
    {
        activeWeapon.rigController.SetBool("Take", true);
    }//guarda a arma caso esteja em suas mãos.
    public void SacarArma()
    {
        activeWeapon.rigController.SetBool("Take", false);
    }
    public void StopCamera(int speedY, int speedX)
    {
        freeLookCamera.m_XAxis.m_MaxSpeed = speedX;
        freeLookCamera.m_YAxis.m_MaxSpeed = speedY;
    }//para a camera quando o jogador pausa o 


    public void All()
    {
        CharacterMoviment();
        CharacterView();
        OpenInventory();
        EquipWeapon();
        Drop();
    }

    public IEnumerator Run()
    {
        GuardarArma();
        while (Input.GetKey(KeyCode.LeftShift))
        {
            if (Player.singleton.carterScene.carter.stamina > 1)
            {
                Player.singleton.carterScene.carterStatus.regen = false;
                anim.SetBool("Running", true);
                Player.singleton.carterScene.carter.stamina -= 0.03f;
                Player.singleton.carterScene.carterStatus.UpdateUI(Player.singleton.carterScene.carter.stamina, Player.singleton.carterScene.carter.staminaFull, Player.singleton.carterScene.carterStatus.staminaImage);
                yield return new WaitForSeconds(2);
            }
            else
            {
                anim.SetBool("Running", false);
                yield return null;
            }
        }
        anim.SetBool("Running", false);
        if (Player.singleton.carterScene.carterStatus.regen == false)
        {
            StartCoroutine(Player.singleton.carterScene.carterStatus.RegenStamina(2, 2));
        }
        yield return null;
    }
}

