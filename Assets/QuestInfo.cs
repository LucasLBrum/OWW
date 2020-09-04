using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct QuestInfo
{
    public string title;
    public string description; 

    public QuestInfo(string Title, string Descripton)
    {
        title = Title;
        description = Descripton;
    }
}
