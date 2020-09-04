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
