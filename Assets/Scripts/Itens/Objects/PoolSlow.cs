using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSlow : MonoBehaviour
{
    public Animator character;
    bool colidindo;


    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CarterStatus>())
        {
            character = other.GetComponent<Animator>();
            character.speed = 0.6f;
            colidindo = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<CarterStatus>())
        {
            character.speed = 1f;
            colidindo = false;
        }
    }

    private void Start()
    {
        StartCoroutine(Backvelocity());
        GetComponent<AudioSource>().volume = GameConfig.singleton.volumeAudios;
        GetComponent<AudioSource>().Play();
    }

    IEnumerator Backvelocity()
    {
        int time = 0;
        while(time < 8)
        {
            time++;
            yield return new WaitForSeconds(1);
        }
        if(colidindo == true){
            if(character != null)
            character.speed = 1;
        }
        Destroy(this.gameObject);
        yield return null;

    }
}
