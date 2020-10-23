using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrowScene : CharacterScene
{
    Crow crow = new Crow("", 1, 1, 10);
    public WitchNecromancerScene witch;
    public bool follow = true;
    public float speed = 1;
    public GameObject player;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        crow.characterPrefab = gameObject;
        thisCharacter = crow;
        player = Player.singleton.carterScene.gameObject;
    }
    private void Start()
    {
        GetComponent<AudioSource>().volume = GameConfig.singleton.volumeAudios;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 10f);
    }
    private void Update()
    {
        if(follow == true)
        {
            transform.LookAt(player.transform.position);
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
