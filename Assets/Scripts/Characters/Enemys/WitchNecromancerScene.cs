using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WitchNecromancerScene : CharacterScene
{
    public GameObject box;
    public GameObject esqueleton;
    public GameObject crow;

    public GameObject pivot;
    public GameObject pivot1;
    public GameObject pivot2;

    public WitchNecromancer necromancer = new WitchNecromancer("necromancer", 50, 50, 20);

    private void Awake()
    {
        necromancer.characterPrefab = gameObject;
        anim = GetComponent<Animator>();
        thisCharacter = necromancer;
    }
    public void SpawnEsqueleton()
    {
        transform.LookAt(Player.singleton.carterScene.transform.position);
        var a = Instantiate(box, pivot.transform.position, pivot.transform.rotation, null);
        var b = Instantiate(box, pivot1.transform.position, pivot1.transform.rotation, null);
    }

    public void SpawnCrow()
    {
        transform.LookAt(Player.singleton.carterScene.transform.position);
        var a = Instantiate(crow, pivot2.transform.position, pivot2.transform.rotation, null);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            transform.LookAt(Player.singleton.carterScene.transform.position);
            anim.SetTrigger("Spawn");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            transform.LookAt(Player.singleton.carterScene.transform.position);
            anim.SetTrigger("SpawnCrow");
        }
    }
}
