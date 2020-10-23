using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCollider : MonoBehaviour
{
    public float damageOnCollison;

    private void Start()
    {
        damageOnCollison = GetComponentInParent<WitchMelee>().witch.damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        var carter = other.GetComponent<CarterStatus>();
        if (carter != null)
        {
            carter.carter.TakeLife(carter.carter, damageOnCollison, 1);
        }
    }
}
