using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_Gun : MonoBehaviour
{
    public Transform hand; //local onde o item ficará após ser coletado.
    public Transform item; //Transform que abrigará o item que está em colisao com o player.
    public Text itemDrop_text; //texto de drop.
    public Text itemCollect_text; // texto de collect.
    private bool Carrying = false; // carregando ou nao algum item.

    private void Start()
    {
        itemCollect_text.enabled = false; //deixa os textos inicialmente desativados.
        itemDrop_text.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //caso o player aperte "E", vera se player esta carregando algum item, caso esteja ela vai soltar e caso nao estaja ele era coletar.
        {
            if (Carrying) //isCarrying == true
            {
                // Soltar
                Drop();
            }
            //Senão...
            else
            {
                //Coletar
                Collect();
            }
        }
    }

    private void Collect()
    {
        if (item == null) return; //retornar a funcao caso nao tenha nenhum item.
        itemCollect_text.enabled = false; //desativa o texto de collect.
        item.position = hand.position; //teleporta o item para a mao do player.
        item.parent = transform; //coloca o item colo "Chidren" do player.
        Carrying = true; //diz que carregando é verdadeiro.
        itemDrop_text.enabled = true; //ativa o texto de drop.
    }

    private void Drop()
    {
        if (Carrying) //se estiver carregando.
        {
            if (item == null) return; //caso nao tenho itens colidindo encerra a funcao.
            Carrying = false; // diz que que nao esta carregando.
            item.position = item.position; //tira o item da mao do player.
            item.parent = null; //faz o item deixar de ser "Children" do player.
            itemDrop_text.enabled = false; //desativa o texto de drop.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") //se o objeto em colisao for um item
        {
            if (!Carrying) //se nao estiver carregando.
            {
                itemCollect_text.enabled = true; //ativa o texto de collect.
                item = other.transform; //faz a variavel "item" abrigar o objeto item.
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Se for "Collectable"...
        if (other.tag == "Item")//se o objeto em colisao for um item
        {
            if (!Carrying)//se nao estiver carregando.
            {
                //Armazenar o objeto que colidiu na referência
                itemCollect_text.enabled = false; //desativa o texto de collect.
                item = null; //deixa a variavel item sem valor.
            }
        }
    }
}
