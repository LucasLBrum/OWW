using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletonScene : CharacterScene
{
    public GameObject pointFire;
    public GameObject pointFire1;

    public GameObject muzzle;

    Esqueleton esqueleton = new Esqueleton("Billy", 100, 100, 20);

    public float raycastDistanceShoot;

    RaycastHit hit;//cria um objeto do tipo "RaycastHit"
    Ray ray;
    public LayerMask raycastMask;
    int mask;

    private void Awake()
    {
        mask = raycastMask.value;
        ray = new Ray(transform.position, transform.forward);
        esqueleton.characterPrefab = gameObject;
        thisCharacter = esqueleton;
        anim = GetComponent<Animator>();
    }

    public void ShootR()
    {
        SpawnMuzzle(pointFire);
        Debug.DrawRay(pointFire.transform.position, pointFire.transform.forward * raycastDistanceShoot, Color.red);

        if (Physics.Raycast(pointFire.transform.position, pointFire.transform.forward, out hit, raycastDistanceShoot, mask, QueryTriggerInteraction.Collide))
        {
            CharacterStatus carter = hit.transform.GetComponent<CharacterStatus>();
            if (carter != null)
            {
                Debug.Log("atirou no player");
            }
        }
        Debug.Log("nenhum inimigo");
    }

    public void ShootL()
    {
        SpawnMuzzle(pointFire1);
        Debug.DrawRay(pointFire1.transform.position, pointFire1.transform.forward * raycastDistanceShoot, Color.red);

        if (Physics.Raycast(pointFire1.transform.position, pointFire1.transform.forward, out hit, raycastDistanceShoot, mask, QueryTriggerInteraction.Collide))
        {
            CharacterStatus carter = hit.transform.GetComponent<CharacterStatus>();
            if (carter != null)
            {
                Debug.Log("atirou no player");
            }
        }
        Debug.Log("nenhum inimigo");
    }

    void SpawnMuzzle(GameObject firePoint)
    {
        if (muzzle != null)
        {
            var muzzleVFX = Instantiate(muzzle, firePoint.transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = firePoint.transform.position;
            muzzleVFX.transform.parent = null;
            var psMuzzle = muzzleVFX.GetComponent<ParticleSystem>();
            if (psMuzzle != null)
            {
                Destroy(muzzleVFX, psMuzzle.main.duration);
            }
            else
            {
                var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(muzzleVFX, psChild.main.duration);
            }
        }
    }
}
