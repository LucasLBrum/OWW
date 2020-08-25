using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public WitchNecromancer witch;
    public bool follow = true;
    public float speed = 1;

    private void Start()
    {
            
    }
    private void Update()
    {
        if(follow == true)
        {
            transform.position += transform.forward * speed; 
            transform.LookAt(Player.singleton.carterScene.inventoryInScene.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterStatus>())
        {
            witch.StartCoroutine(witch.CrowEffect());
            Destroy(gameObject);
        }
    }
}
