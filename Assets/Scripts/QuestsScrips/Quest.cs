using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public QuestInfo questInfo;
    public Npc npc;
    public ObjectiveQuest objectives;
    public GameObject drop;
    public QuestSlot slot;
    public GameObject caution;
    public bool ready;

    void Start()
    {
        objectives = GetComponent<ObjectiveQuest>();
    }

    public void CompleteMission(Transform spawnPosition)
    {
        ready = true;
        var drop = Instantiate(this.drop, spawnPosition.position, Quaternion.identity);
        slot.RemoveQuest();
        caution.SetActive(false);
    }

    public Quest(QuestInfo info, Npc npc, ObjectiveQuest objectives, GameObject drop)
    {
        questInfo = info;
        this.npc = npc;
        this.objectives = objectives;
        this.drop = drop;
    }
}
