using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;//componente de animação.
    Vector2 input;//input para ser usado na movimentação.
    Camera mainCamera; //main camera
    Inventory inventory;
    public CinemachineFreeLook freeLookCamera;//componente da cinemachine 
    CarterStatus status;
    public ActiveWeapon activeWeapon;//componente que contem as refêrencias do rig do jogador.
    public Slot slotWeaponUse;//a arma que esta sendo usada atualmente 

    private void Awake()
    {
        mainCamera = Camera.main;
        activeWeapon = GetComponent<ActiveWeapon>();
        anim = GetComponent<Animator>();//pegar componente desse objeto.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        freeLookCamera = GameObject.Find("CM FreeLook1").GetComponent<CinemachineFreeLook>();
    }
    private void Start()
    {
        inventory = Player.singleton.carterScene.inventoryInScene;
        status = Player.singleton.carterScene.carterStatus;
    }
    public void CharacterMovement() 
    {
            input.x = Input.GetAxisRaw("Horizontal"); //recebe o valor dos parametros da unity de horizontal e vertical.
            input.y = Input.GetAxisRaw("Vertical");

            anim.SetFloat("InputX", input.x, 0.2f, Time.deltaTime);
            anim.SetFloat("InputY", input.y, 0.2f, Time.deltaTime);


            if (Input.GetKey(KeyCode.S) == false)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (status.carter.stamina > 5)
                    {
                        StartCoroutine(Roll());
                    }
                }
            }

            if (Input.GetKey(KeyCode.S) == false)
            {
                if(Input.GetKey(KeyCode.LeftShift))
                StartCoroutine(Run());
            }

          

    }
    public void CharacterView()
    {
        float turnSpeed = 10f;
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y; 
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
    public void EquipWeapon()//Acessar os slots de armas do inventário.
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(inventory.weaponSlot[0].open == false)
            {
                if(slotWeaponUse != null)
                {
                    if (inventory.weaponSlot[0].item == slotWeaponUse.item)
                    {
                        return;
                    }
                }
                if (slotWeaponUse == inventory.weaponSlot[1])
                {
                    activeWeapon.weapon.GetDetailsWeapon(inventory.weaponSlot[1].GetComponent<WeaponInScene>(), activeWeapon.weapon);
                    
                }
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(inventory.weaponSlot[0].item, inventory.weaponSlot[0].GetComponent<WeaponInScene>());
                slotWeaponUse = inventory.weaponSlot[0];
                Game.singleton.estadoJogando.weaponShoot = activeWeapon.weapon.GetComponent<ShootProject>();
            }
        }//Acessar slot 1.
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (inventory.weaponSlot[1].open == false)
            {
                if (slotWeaponUse != null)
                {
                    if (inventory.weaponSlot[1].item == slotWeaponUse.item)
                    {
                        return;
                    }
                }
                if(slotWeaponUse == inventory.weaponSlot[0])
                {
                    activeWeapon.weapon.GetDetailsWeapon(inventory.weaponSlot[0].GetComponent<WeaponInScene>(), activeWeapon.weapon);
                }
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                activeWeapon.Equip(inventory.weaponSlot[1].item, inventory.weaponSlot[1].GetComponent<WeaponInScene>());
                slotWeaponUse = inventory.weaponSlot[1];
                Game.singleton.estadoJogando.weaponShoot = activeWeapon.weapon.GetComponent<ShootProject>();
            }

        }//Acessar slot 2.
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeWeapon.BulletImage.SetActive(false);
            if (activeWeapon.weapon != null)
            {
                if(slotWeaponUse.item == inventory.weaponSlot[0].item)
                {
                    activeWeapon.weapon.GetDetailsWeapon(inventory.weaponSlot[0].GetComponent<WeaponInScene>(),activeWeapon.weapon);
                }
                else if(slotWeaponUse.item == inventory.weaponSlot[1].item)
                {
                    activeWeapon.weapon.GetDetailsWeapon(inventory.weaponSlot[1].GetComponent<WeaponInScene>(), activeWeapon.weapon);
                }
                activeWeapon.rigController.SetBool("Take", false);
                Destroy(activeWeapon.weaponObject);
                activeWeapon.weapon = null;
                slotWeaponUse = null;
                activeWeapon.handIK.weight = 0;
                activeWeapon.rigController.Play("Default");
            }
        }//Ficar com as mãos nuas.
        if(activeWeapon.weapon != null)
        {
            inventory.atualWeapon = activeWeapon.weapon;
            inventory.UpdateMunitionText();
        }


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
                activeWeapon.BulletImage.SetActive(false);
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

    }//guarda a arma caso esteja em suas mãos.
    public void StopCamera(bool op)
    {
        if(op == true)
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 0;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0;
        }
        else
        {
            if(GameConfig.singleton != null)
            {
                freeLookCamera.m_XAxis.m_MaxSpeed = GameConfig.singleton.speedX;
                freeLookCamera.m_YAxis.m_MaxSpeed = GameConfig.singleton.speedY;
            }
            else
            {
                freeLookCamera.m_XAxis.m_MaxSpeed = 300;
                freeLookCamera.m_YAxis.m_MaxSpeed = 2;

            }

        }

    }//para a camera quando o jogador pausa o 
    public IEnumerator Run()
    {
        activeWeapon.rigController.SetBool("Take", true);
        if(activeWeapon.weapon)
        {
            activeWeapon.weapon.GetComponent<ShootProject>().loadingPower = false;
        }
        while (Input.GetKey(KeyCode.LeftShift))
        {
            if (status.carter.stamina > 1)
            {
                status.regen = false;
                anim.SetBool("Running", true);
                status.carter.stamina -= status.StaminaPrice;
                status.UpdateStamina();
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                anim.SetBool("Running", false);
                yield return null;
            }
        }
        anim.SetBool("Running", false);

        if (status.regen == false)
        {
            StartCoroutine(status.RegenStamina());
        }
        if(activeWeapon.weapon != null)
        {
            activeWeapon.rigController.SetBool("Take", false);
        }

        yield return null;
    }
    public IEnumerator Roll()
    {
        anim.SetTrigger("Roll");
        if(activeWeapon.weapon != null)
        {
            activeWeapon.weapon.GetComponent<ShootProject>().loadingPower = false;
            activeWeapon.rigController.SetBool("Take", true);
        }
        status.TakeStamina(5);
        yield return new WaitUntil(WaitStateRoll);
        while(anim.GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            yield return new WaitForSeconds(0.1f);
        }
        if(activeWeapon.weapon != null)
        {
            activeWeapon.rigController.SetBool("Take", false);
        }
        if(status.regen == false)
        {
            StartCoroutine(status.RegenStamina());
        }
        yield return null;
    }
    bool WaitStateRoll()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("Roll");
    }
}