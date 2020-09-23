using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMission : MonoBehaviour
{
    public Collider blockWay;

    public Quest[] quests;

    public void DesableColliser()
    {
        blockWay.enabled = false;
    }

    public void VerificationQuests()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            if(quests[i].ready == false)
            {
                return;
            }
        }
        blockWay.enabled = false;
    }
}
