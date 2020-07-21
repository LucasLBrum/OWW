using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    [SerializeField]
    float raycastDistance = 10f;
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


    void Update()
    {
        PerformRaycast();
    }

    void PerformRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);

        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, mask, QueryTriggerInteraction.Collide))
        {
            var interactable = hit.transform.GetComponent<ItemScene>();
            if (interactable != null)
            {
                //print($"Colidiu {hit.transform.name} no ponto {hit.point}");
                pickUp.PickUp(interactable.gameObject);
            }
        }
    }
   
}
