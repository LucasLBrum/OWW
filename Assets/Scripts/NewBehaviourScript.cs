using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>

    AudioScript Audio;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            Audio.Passo();
        }
    }
}
