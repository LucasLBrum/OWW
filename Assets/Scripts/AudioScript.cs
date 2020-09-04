using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip passo;
    public AudioClip passo1;

    public AudioClip pickUpAudio;

    AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    
    
    public void Passo()
    {
        source.PlayOneShot(passo);
        return;
    }

    public void Passo1()
    {
        source.PlayOneShot(passo1);
        return;
        
    }

    public void PickUpSound(){
        source.PlayOneShot(pickUpAudio);
        return;
    }

}
