using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;


public class OutlineChildren : MonoBehaviour
{
    public GameObject parent;
    public Outline[] outlines;

    void Start()
    {
        outlines = parent.GetComponentsInChildren<Outline>();
        ActiveOutlines(false);
    }

    
    public void ActiveOutlines(bool op)
    {
        for (int i = 0; i < outlines.Length; i++)//verifico a quantidade de itens na lista
        {
            outlines[i].enabled = op;
        }
    }
}
