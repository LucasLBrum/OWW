using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRange : MonoBehaviour
{
    public GameObject[] parts = new GameObject[32];
    public Material glassMaterial;
    void Start()
    {
        GetRef();
        StartCoroutine(ChangeMaterial());
    }

    void GetRef()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            parts[i] = gameObject.transform.GetChild(i).gameObject;
            parts[i].GetComponent<MeshRenderer>().enabled = false;
        }
    }

    IEnumerator ChangeMaterial()
   {
        int i = 0;
        while(i < parts.Length)
        {
            parts[i].GetComponent<MeshRenderer>().enabled = true;
            parts[i].GetComponent<MeshRenderer>().material = glassMaterial;
            i++;
            yield return new WaitForSeconds(0.08f);

        }

        yield return null;
   }
}
