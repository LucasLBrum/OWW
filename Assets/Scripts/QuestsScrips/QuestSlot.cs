using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestSlot : MonoBehaviour
{
    public Text descritionQuests;
    public Text titleQuests;
    public Text progressText;

    public Quest quest = null;

    public void AddQuest(Quest otherQuest)
    {
        quest = otherQuest;
        descritionQuests.text = quest.objectives.description;
        titleQuests.text = quest.questInfo.title;
        progressText.text = quest.objectives.progress.ToString();
        quest.slot = this;
    }

    public void RemoveQuest()
    {
        descritionQuests.text = "";
        titleQuests.text = "";
        progressText.text = "";
        quest = null;
    }

}
