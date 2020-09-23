using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Npc : MonoBehaviour
{
    public string[] talkText;
    public string talkText2;
    public int atualText = 0;
    public Quest quest = null;
    public Transform dropPosition;
    public Text talkText_m;
    public NpcType type;


    void Start()
    {
        talkText_m = Game.singleton.talkText;
    }
    
    public void Intectable()
    {
        Player.singleton.questManager.npc = this;
        if(quest != null)
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
            Game.singleton.estadoFalando.EnterState();
            talkText_m.text = talkText[atualText];
        }

        if(quest == null)
        {
            if(type == NpcType.Repeat)
            {
                atualText = 0;
                Game.singleton.estadoFalando.EnterState();
                talkText_m.text = talkText[atualText];
                return;
            }
            if(atualText >= talkText.Length)
            {
                return;
            }
            Game.singleton.estadoFalando.EnterState();
            talkText_m.text = talkText[atualText];
        }

        if(quest != null)
        if(quest.ready == true)
        {
            Game.singleton.estadoFalando.EnterState();
            talkText_m.text = talkText2;
        }

    }
}
public enum NpcType
{
    Repeat, OneInteractable
}