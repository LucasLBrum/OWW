using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Npc : MonoBehaviour
{
    public string[] talkText;
    public string talkText2;
    int atualText = 0;
    public Text talkText_m;
    public Quest quest = null;
    public Transform dropPosition;

    public void Intectable()
    {
        if(quest.ready == false)
        {
            if(quest.objectives.complete)
            {
                quest.CompleteMission(dropPosition);
                return;
            }

            if(atualText >= talkText.Length)
            {
                return;
            }
            Game.singleton.estadoFalando.EnterState(this);
            talkText_m.text = talkText[atualText];
        }

        if(quest.ready == true)
        {
            Game.singleton.estadoFalando.EnterState(this);
            talkText_m.text = talkText2;
        }

    }

    public void NextIntec()
    {
        if(quest.ready)
        {
            Game.singleton.estadoFalando.ExitState();
            return;
        }
        atualText++;
        if(atualText >= talkText.Length)
        {
            Game.singleton.estadoFalando.ExitState();
            if(quest != null)
            {
                Player.singleton.questManager.AddQuest(quest);
            }

            return;
        }
        talkText_m.text = talkText[atualText];
    }
    
}
