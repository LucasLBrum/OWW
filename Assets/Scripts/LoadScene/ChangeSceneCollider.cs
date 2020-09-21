using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneCollider : MonoBehaviour
{
    public ChangeSceneButton changeScene;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CarterStatus>())
        {
            Game.singleton.loadState.EnterState();
            changeScene.ChangeScene("Florest");
        }
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Game.singleton.loadState.EnterState();
            changeScene.ChangeScene("Florest");
        }
    }
}
