using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent; //Agente do navmesh
    Animator anim;//componenete de animação desse objeto
    public bool inBattle;
    [SerializeField]
    private float maxDistance;
    Enemy enemy;
    bool alive;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();//pegando refêrencia dos componenetes nesse objeto.
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }


    private void Update()
    {
        Movement();
    }


    void Movement()
    {
        if (inBattle)
        {
            float distance = Vector3.Distance(transform.position, Player.singleton.carterScene.transform.position);//a variável "distance", agora recebe a distancia entre o agente e o player.

            if (distance > maxDistance)// caso ele esteja longe do jogador
            {
                agent.updatePosition = true; //caso a distancia seja mais que 1.5 o inimigo continua atuzlizando sua posição 
                agent.SetDestination(Player.singleton.carterScene.transform.position); //e o player continua sendo seu destino
                anim.SetBool("isLocomotion", true);//ele continua execultando a animação de locomoção
                anim.SetBool("isAtack", false);
            }
            else// caso ele esteja perto do jogador
            {
                agent.updatePosition = false;//ele para de andar
                anim.SetBool("isLocomotion", false);//para de fazer a animação de locomoção
                transform.LookAt(Player.singleton.carterScene.transform);//olha para o player
                anim.SetBool("isAtack", true);//faz animação de ataque
            }
        }
    }
}
