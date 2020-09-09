using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepit : MonoBehaviour
{
    public GameObject StatusImage;
    public Carter carter;



    /// <summary>
    /// OnTriggerStay is called once per frame for every Collider other
    /// that is touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerStay(Collider other)
    {
        var carterScene = other.GetComponent<CarterScene>();
        if(carterScene != null)
        {
            carter = carterScene.carter;
            if(Input.GetKeyDown(KeyCode.E))
            {
                StatusImage.SetActive(true);
            }

        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other)
    {
        StatusImage.SetActive(false);
    }
}
