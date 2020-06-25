using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
    [SerializeField]
    float raycastDistance = 20f;
    RaycastHit hit;//cria um objeto do tipo "RaycastHit"
    Ray ray;

    public LayerMask raycastMask;

    int mask;

    private void Start()
    {
        mask = raycastMask.value;

        ray = new Ray(transform.position, transform.forward);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
   {
        //Shoot();//invocando a funcao
        //PerformRaycast();
   }

    void PerformRaycast()
    {
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);

        if(Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance, mask, QueryTriggerInteraction.Collide))
        //if (Physics.Raycast(ray, out hit, raycastDistance, mask))
        {          
            var interactable = hit.transform.GetComponent<Interactable>();

            if(interactable != null)
            {
                print($"Colidiu {hit.transform.name} no ponto {hit.point}");
            }
        }
    }

    /*
   void Shoot() //Função de tiro da  arma
   {
      if(Input.GetKey(KeyCode.Mouse0)) //se apertar com o botão esquerdo do mouse...
      {
         if(Physics.Raycast(transform.position, transform.forward, out hit, 1000f))//cria o raycast, dando uma direção, um alvo e uma distancia maxima.
         {
            print($"Colidiu {hit.transform.name} no ponto {hit.point}"); //print do noem do objeto com qual o hit colidiu
            Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red); //desenha uma linha do objeto pai ao hit
         }
      }
   }
   */
   
}
