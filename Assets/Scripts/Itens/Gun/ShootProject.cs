using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProject : MonoBehaviour
{
    public GameObject FirePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public Animator rigController;

    private GameObject effectToSpawn;
    float timeTofire = 0;

    private void Start()
    {
        effectToSpawn = vfx[0];
    }

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
                if (Input.GetMouseButton(0) && Time.time >= timeTofire)
                {

                    if (rigController.GetBool("Take") == false)
                    {

                        rigController.Play("weapon_recoil_" + GetComponent<WeaponInScene>().weaponName, 1, 0.0f);
                        timeTofire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
                        SpawnVFX();
                    }
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    rigController.SetTrigger("Reload");
                }
            }
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        if(FirePoint != null)
        {
            vfx = Instantiate(effectToSpawn, FirePoint.transform.position, FirePoint.transform.rotation);
        }
        else
        {
            Debug.Log("No Fire Points");
        }
    }
}
