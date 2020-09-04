using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Npc : MonoBehaviour
{
    public string[] talkText;
    int atualText = 0;
    public GameObject box;
    public Text talkText_m;
    public Quest quest = null;

    public Transform dropPosition;

    public void Intectable()
    {
        if(quest != null)
        {
            if(quest.objectives.complete)
            {
                quest.CompleteMission(dropPosition);
            }
        }
        if(atualText >= talkText.Length)
        {
            return;
        }
        Game.singleton.estadoFalando.EnterState();
        box.SetActive(true);
        talkText_m.text = talkText[atualText];
    }

    public void NextIntec()
    {
        atualText++;
        if(atualText >= talkText.Length)
        {
            atualText = 0;
            box.SetActive(false);
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
