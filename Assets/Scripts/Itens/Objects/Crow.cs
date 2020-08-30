using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class Crow : MonoBehaviour
{
    public WitchNecromancer witch;
    public bool follow = true;
    public float speed = 1;
    public PostProcessVolume ppv;


    private void Start()
    {
        ppv = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>();
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
            StartCoroutine(CrowEffect());
            Destroy(gameObject);
        }
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
}
