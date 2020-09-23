using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QuestManager : MonoBehaviour
{
    public List<QuestSlot> quests;
    public ColliderMission cMission;
    public Npc npc;

    public void AddQuest(Quest quest)
    {
        for (int i = 0; i < quests.Count; i++)
        { 
            if(quests[i].quest == null)
            {
               quests[i].AddQuest(quest); 
               return;
            }
        }
    }
    public void NextIntec()
    {
        if(cMission != null)
        {
            cMission.VerificationQuests();
        }
        if(npc.quest != null)
        if(npc.quest.ready)
        {
            Game.singleton.estadoFalando.ExitState();
            return;
        }
        npc.atualText++;
        if(npc.atualText >= npc.talkText.Length)
        {
            Game.singleton.estadoFalando.ExitState();
            if(npc.quest != null)
            {
                Player.singleton.questManager.AddQuest(npc.quest);
            }

            return;
        }
        npc.talkText_m.text = npc.talkText[npc.atualText];
    }
}
