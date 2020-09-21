using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    float raycastDistancePickup = 10f;
    public float raycastDistanceShoot = 25f;
    public PickUpItem pickUp;
    public GameObject blood;
    public GameObject smoke;
    public ItemScene item;
    Npc npc;
    OutlineChildren lineChildren;

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
            var outline = hit.transform.GetComponent<OutlineChildren>();
            if(outline != null)
            {
                lineChildren = outline;
                lineChildren.ActiveOutlines(true);
            }
            else
            {
                if(lineChildren != null)
                {
                    lineChildren.ActiveOutlines(false);
                    lineChildren = null;
                }
            }
            var interactable = hit.transform.GetComponent<ItemScene>();
            if (interactable != null)
            {
                item = interactable;
                pickUp.PickUp(interactable.gameObject);
            }
            var munition = hit.transform.GetComponent<Munition>();
            if (munition != null)
            {
                pickUp.PickUp(munition.gameObject);
            }
            var npc = hit.transform.GetComponent<Npc>();
            if(npc != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    npc.GetComponent<Npc>().Intectable();
                }
            }
            var money = hit.transform.GetComponent<MoneyScene>();
            if(money != null)
            {
                pickUp.PickUp(money.gameObject);
            }
            var market = hit.transform.GetComponent<MarketInteractable>();
            if(market != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Game.singleton.estadoComprando.EnterState();
                }
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
