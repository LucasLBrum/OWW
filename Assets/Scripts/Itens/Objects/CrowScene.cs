using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrowScene : CharacterScene
{
    Crow crow = new Crow("", 1, 1, 10);
    public WitchNecromancerScene witch;
    public bool follow = true;
    public float speed = 1;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        crow.characterPrefab = gameObject;
        thisCharacter = crow;
    }
    private void Start()
    {
        transform.LookAt(Player.singleton.carterScene.inventoryInScene.transform.position);
    }
    private void Update()
    {
        if(follow == true)
        {
            transform.position += transform.forward * speed; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterStatus>())
        {
            witch.StartCoroutine(witch.CrowEffect());
        }
         Destroy(gameObject);
    }

    public void DestroyCrow()
    {
        Destroy(gameObject);
    }


}
