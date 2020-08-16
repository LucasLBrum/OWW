using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSlow : MonoBehaviour
{
    CharacterStatus character;

    private void OnTriggerStay(Collider other)
    {
        character = other.GetComponentInChildren<CharacterStatus>();
        if (character != null)
        {
            character.GetComponent<Animator>().speed = 0.5f;
            character.TakeValueAndUpdate(0.3f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        character.GetComponent<Animator>().speed = 1;
    }

    private void Start()
    {
        Destroy(gameObject, 15);
    }

}
