using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProject : MonoBehaviour
{
    public GameObject FirePoint;
    public List<GameObject> vfx = new List<GameObject>();

    private GameObject effectToSpawn;
    float timeTofire = 0;

    private void Start()
    {
        effectToSpawn = vfx[0];
    }

    private void Update()
    {
        if(Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse != null)
        {
            if (GetComponent<ItemScene>().thisItem == Player.singleton.carterScene.GetComponent<PlayerMovement>().slotWeaponUse.item)
            {
                if (Input.GetMouseButton(0) && Time.time >= timeTofire)
                {
                    timeTofire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
                    SpawnVFX();
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
