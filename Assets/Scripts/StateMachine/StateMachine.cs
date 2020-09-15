using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    //Estados locais

    public State currentState;
    private State previousState;
    
    //Métodos
    public void RunState()
    {
        if(currentState != null)
        {
            currentState.Execute();
        }
    }

    public void ChangeState(State newState)
    {
        if (newState == currentState)
        {
            Debug.Log("Já está no estado " + currentState.Name);
            
            return;
        }
            
        else
        {
            //Estado anterior vai receber o estado que está rodando na máquina
            previousState = currentState;

            if(previousState != null)
                Debug.Log(previousState.Name);

            Debug.Log(newState.Name);
            //Estado atual da máquina recebe o novo estado do parâmetro
            currentState = newState;
        }
    }

}
