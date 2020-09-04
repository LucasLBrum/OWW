using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestElement : MonoBehaviour
{
    public ObjectiveQuest request;
    public int progressValue;


    public void CompleteRequest()
    {
        request.AddProgress(progressValue);
    }
}
