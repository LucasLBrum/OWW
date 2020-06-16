using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRaycast : MonoBehaviour
{
   RaycastHit hit;//cria um objeto do tipo "RaycastHit"



   /// <summary>
   /// Update is called every frame, if the MonoBehaviour is enabled.
   /// </summary>
   void Update()
   {
      Shoot();//invocando a funcao
   }

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
   
}
