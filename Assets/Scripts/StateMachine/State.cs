using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public string Name { get; set; }
    
    public virtual void Execute()
    {
        Debug.Log("Executando o estado " + Name);
    }

    public virtual void EnterState(){}
    public virtual void ExitState(){}
}