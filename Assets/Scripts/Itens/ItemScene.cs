using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;
public class ItemScene : MonoBehaviour
{
    public ItemResource thisItem;
    public Outline[] outlines;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>

    public void ActiveOutlines(bool op)
    {
        for (int i = 0; i < outlines.Length; i++)//verifico a quantidade de itens na lista
        {
            outlines[i].enabled = op;
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        outlines = GetComponentsInChildren<Outline>();
        ActiveOutlines(false);
    }
}
