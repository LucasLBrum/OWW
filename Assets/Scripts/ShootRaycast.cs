using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    float raycastDistancePickup = 10f;
    float raycastDistanceShoot = 25f;
    public PickUpItem pickUp;
    public GameObject blood;
    public GameObject smoke;
    public GameObject e;
    public ItemScene a;
    RaycastHit hit;//cria um objeto do tipo "RaycastHit"
    Ray ray;

    public LayerMask raycastMask;

    int mask;

    private void Start()
    {
        mask = raycastMask.value;

        ray = new Ray(transform.position, transform.forward);
    }

    public void PerformRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistancePickup, Color.green);

        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistancePickup, mask, QueryTriggerInteraction.Collide))
        {
            var interactable = hit.transform.GetComponent<ItemScene>();
            if (interactable != null)
            {
                if(a != null)
                {
                    if(a != interactable)
                    {
                        a.ActiveOutlines(false);
                    }
                }
                a = interactable;
                a.ActiveOutlines(true);
                pickUp.PickUp(interactable.gameObject);
                e.SetActive(true);
            }
            var munition = hit.transform.GetComponent<Munition>();
            if (munition != null)
            {
                pickUp.PickUp(munition.gameObject);
                e.SetActive(true);
            }
            var npc = hit.transform.GetComponent<Npc>();
            if(npc != null)
            {
                e.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    npc.GetComponent<Npc>().Intectable();
                }
            }
        }
        else
        {
            e.SetActive(false);
            if(a != null){
                a.ActiveOutlines(false);
                a = null;
            }
        }
    } 
   
    public EnemyStatus ShootR()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistanceShoot, Color.red);
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistanceShoot, mask, QueryTriggerInteraction.Collide))
        {
            EnemyStatus enemy = hit.transform.GetComponent<EnemyStatus>();
            if (enemy != null)
            {
                var blood = Instantiate(this.blood, hit.point, Quaternion.identity);
                Destroy(blood, 1);
                Debug.Log("atirou no inimigo");
                return enemy;
            }
            else
            {
                var smoke = Instantiate(this.smoke, hit.point, Quaternion.identity);
                Destroy(smoke, 1);
            }
        }

        Debug.Log("nenhum inimigo");
        return null;
    }
}
