using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProject : MonoBehaviour
{
    public GameObject FirePoint;
    public Animator rigController;

    public ParticleSystem effectToSpawn;
    float timeTofire = 0;

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse != null)
        {
            if (GetComponent<ItemScene>().thisItem == Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse.item)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= timeTofire)
                {

                    if (rigController.GetBool("Take") == false)
                    {
                        rigController.Play("weapon_recoil_" + GetComponent<WeaponInScene>().weaponName, 1, 0.0f);
                        effectToSpawn.Emit(1);
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    rigController.SetTrigger("Reload");
                }
            }
        }
    }
}
