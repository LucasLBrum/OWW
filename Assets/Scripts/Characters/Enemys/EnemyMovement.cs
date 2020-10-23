using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using System;
using cakeslice;


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent; //Agente do navmesh
    Animator anim;//componenete de animação desse objeto
    public CarterScene carter;
    public Character enemy;
    [SerializeField]
    private float maxDistance = 3;
    [SerializeField]
    public GameObject DropItem = null;
    public bool inBattle;
    public Outline[] outlines;
    public  IEnumerator chaseC;
    public bool a;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();//pegando refêrencia dos componenetes nesse objeto.
        anim = GetComponent<Animator>();
        outlines = GetComponentsInChildren<Outline>();
        ActiveOutlines(true);
    }

    private void Start()
    {
        a = false;
        chaseC = Chase();
        carter = Player.singleton.carterScene;
        enemy = GetComponent<CharacterScene>().thisCharacter;
        if(inBattle)
        {
            StartCoroutine(Chase());
        }
    }
    public void ActiveOutlines(bool op)
    {
        for (int i = 0; i < outlines.Length; i++)//verifico a quantidade de itens na lista
        {
            outlines[i].enabled = op;
        }
    }
    public IEnumerator Chase()
    {
        inBattle = true;
        float distance = Vector3.Distance(transform.position, carter.transform.position);//a variável "distance", agora recebe a distancia entre o agente e o player.
        while (enemy.lifeCharacter > 0 && carter.carter.lifeCharacter > 0)
        {
            distance = Vector3.Distance(transform.position, carter.transform.position);//a variável "distance", agora recebe a distancia entre o agente e o player.  

            if (distance > maxDistance)// caso ele esteja longe do jogador
            {
                if(GetComponent<EsqueletonScene>() != null)
                {
                    if(a == false)
                    {
                        StartCoroutine(chaseC);
                        a = true;
                        yield return null;
                    }

                }

                if(anim.GetBool("isAtack") == true)
                {
                    anim.SetBool("isAtack", false);
                    yield return new WaitUntil(WaitStateAtack);
                    while(anim.GetCurrentAnimatorStateInfo(0).IsName("Atack"))
                    {
                        Debug.Log("em corountine");
                        yield return new WaitForSeconds(0.1f);
                    }
                }
                agent.updatePosition = true; //caso a distancia seja mais que 1.5 o inimigo continua atuzlizando sua posição 
                agent.SetDestination(carter.transform.position); //e o player continua sendo seu destino
                anim.SetBool("isLocomotion", true);//ele continua execultando a animação de locomoção
                anim.SetBool("isAtack", false);
            }
            else// caso ele esteja perto do jogador
            {
                agent.updatePosition = false;//ele para de andar
                anim.SetBool("isLocomotion", false);//para de fazer a animação de locomoção
                transform.LookAt(carter.transform);//olha para o player
                anim.SetBool("isAtack", true);//faz animação de ataque
            }
            yield return new WaitForSeconds(0.8f);
        }
        if(carter.carter.lifeCharacter > 0)
        {
            agent.updatePosition = false;//ele para de andar
            anim.SetBool("isLocomotion", false);//para de fazer a animação de locomoção
            anim.SetBool("isAtack", true);//faz animação de ataque
        }
        if(enemy.lifeCharacter > 0)
        {
            agent.updatePosition = false;//ele para de andar
            anim.SetBool("isLocomotion", false);//para de fazer a animação de locomoção
            anim.SetBool("isAtack", false);//faz animação de ataque
            anim.SetTrigger("celebrate");//faz animação de ataque
        }
    }
    public void DeadFuncion()
    {
        if(GetComponent<WitchMelee>() != null)
        {
            GetComponent<WitchMelee>().colliderAtack.SetActive(false);
        }
        if(GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        if(DropItem != null)
        {
            Instantiate(DropItem, transform.position, Quaternion.identity);
        }
        if(GetComponent<EnemyStatus>().lifeSlider != null)
        {
            GetComponent<EnemyStatus>().lifeSlider.gameObject.SetActive(false);
        }
        ActiveOutlines(false);
        GetComponent<Collider>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
    }
    public void StopEnemy()
    {
        agent.updatePosition = false;//ele para de andar
        anim.SetBool("isLocomotion", false);//para de fazer a animação de locomoção
        anim.SetBool("isAtack", false);//faz animação de ataque
    }

    bool WaitStateAtack()
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName("Atack");
    }
}
