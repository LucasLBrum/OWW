using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour
{
    public List<QuestSlot> quests;

    public void AddQuest(Quest quest)
    {
        for (int i = 0; i < quests.Count; i++)
        { 
            if(quests[i].quest == null)
            {
               quests[i].AddQuest(quest); 
               return;
            }
            i++;
        }
    }
}
