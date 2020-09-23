using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveQuest : MonoBehaviour
{
    public string description;
    public bool complete;
    public int progress;
    public Quest quest;

    void Start()
    {
        quest = GetComponent<Quest>();
    }

    public TypeRequest type;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    public bool VerificationState()
    {
        if(progress == 100)
        {
            return true;
        }
        else
        {
            Debug.Log("A missão está inacabada");
            return false;
        }
    }

    public void AddProgress(int value)
    {
        progress += value;
        quest.slot.progressText.text = progress.ToString();
        complete = VerificationState();
    }
}

public enum TypeRequest
{
    enemy, item
}
