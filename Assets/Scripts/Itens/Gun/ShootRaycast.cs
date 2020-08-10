using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    float raycastDistancePickup = 10f;
    float raycastDistanceShoot = 25f;
    public PickUpItem pickUp;
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
                pickUp.PickUp(interactable.gameObject);
            }
            var munition = hit.transform.GetComponent<Munition>();
            if (munition != null)
            {
                pickUp.PickUp(munition.gameObject);
            }
        }
    } 
   
    public Enemy ShootR()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistanceShoot, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistanceShoot, mask, QueryTriggerInteraction.Collide))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("atirou no inimigo");
                return enemy;
            }
        }

        Debug.Log("nenhum inimigo");
        return null;
    } 
}
