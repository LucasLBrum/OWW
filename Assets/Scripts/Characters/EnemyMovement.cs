using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.singleton.carterScene.transform.position);

        if(distance > 1.5)
        {
            agent.updatePosition = true;
            agent.SetDestination(Player.singleton.carterScene.transform.position);
            anim.SetBool("isLocomotion", true);
            anim.SetBool("isAtack", false);
        }
        else
        {
            agent.updatePosition = false;
            anim.SetBool("isLocomotion", false);
            transform.LookAt(Player.singleton.carterScene.transform);
            anim.SetBool("isAtack", true);
        }
    }
}
