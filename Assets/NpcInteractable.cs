using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteractable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Npc>())
        {
            Player.singleton.intectableText.enabled = true;
            Player.singleton.intectableText.text = "Pressione E para começar a interação.";
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.GetComponent<Npc>())
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<Npc>().Intectable();
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Player.singleton.intectableText.enabled = false;
    }
}
