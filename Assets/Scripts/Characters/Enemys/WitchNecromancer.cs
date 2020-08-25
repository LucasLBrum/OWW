using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class WitchNecromancer : Enemy
{
    public GameObject box;
    public GameObject esqueleton;
    public GameObject crow;

    public GameObject pivot;
    public GameObject pivot1;
    public GameObject pivot2;

    public PostProcessVolume ppv;

    Animator anim;

    private void Start()
    {
        ppv = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>();
        anim = GetComponent<Animator>();
    }

    public void SpawnEsqueleton()
    {
        transform.LookAt(Player.singleton.carterScene.transform.position);
        var a = Instantiate(box, pivot.transform.position, pivot.transform.rotation, null);
        var b = Instantiate(box, pivot1.transform.position, pivot1.transform.rotation, null);
        //a.transform.LookAt(Player.singleton.carterScene.transform);

    }

    public void SpawnCrow()
    {
        transform.LookAt(Player.singleton.carterScene.transform.position);
        var a = Instantiate(crow, pivot2.transform.position, pivot2.transform.rotation, null);
        a.GetComponent<Crow>().follow = true;
        a.GetComponent<Crow>().witch = this;
    }

    public IEnumerator CrowEffect()
    {
        float time = 1;
        while (time <= 10)
        {
            ppv.weight = 1;
            time++;
            Debug.Log(time);
            yield return new WaitForSeconds(1f);
        }
        ppv.weight = 0;
        yield return null;
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
