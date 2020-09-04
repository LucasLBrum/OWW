using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;



public class WitchNecromancerScene : CharacterScene
{
    public GameObject box;
    public GameObject crow;
    public GameObject pivot;
    public GameObject pivot1;
    public GameObject pivot2;

    public PostProcessVolume ppv;

    bool esqueletonSpawn;

    public WitchNecromancer necromancer = new WitchNecromancer("necromancer", 50, 50, 20);

    private void Awake()
    {
        esqueletonSpawn = false;
        necromancer.characterPrefab = gameObject;
        anim = GetComponent<Animator>();
        thisCharacter = necromancer;
        ppv = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>();
    }
    public void SpawnEsqueleton()
    {
        esqueletonSpawn = true;
        transform.LookAt(Player.singleton.carterScene.transform.position);
        var a = Instantiate(box, pivot.transform.position, pivot.transform.rotation, null);
        var b = Instantiate(box, pivot1.transform.position, pivot1.transform.rotation, null);
    }

    public void ExecuteAnimationSpawn()
    {
        if (esqueletonSpawn == false)
        {
            esqueletonSpawn = true; 
            anim.Play("Spawn");
        }
    }

    public void SpawnCrow()
    {
        transform.LookAt(Player.singleton.carterScene.transform.position);
        var a = Instantiate(crow, pivot2.transform.position, pivot2.transform.rotation, null);
        a.GetComponent<CrowScene>().witch = this;
    }

    public void LookToPlayer()
    {
        transform.LookAt(Player.singleton.carterScene.transform.position);
    }

    public IEnumerator CrowEffect()
    {
        float time = 1;
        while (time < 3)
        {
            ppv.weight = 1;
            time++;
            Debug.Log(time);
            yield return new WaitForSeconds(1f);
        }
        ppv.weight = 0;
        yield return null;
    }
}
