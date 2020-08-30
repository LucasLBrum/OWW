using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollider : MonoBehaviour
{
    public float damageOnCollison;
    private void OnTriggerEnter(Collider other)
    {
        var carter = other.GetComponent<CharacterStatus>();
        if (carter != null)
        {
            //carter.TakeValueAndUpdate(damageOnCollison);
        }
    }
}
