using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    

    public void Initialize()
    {
        changeState(new PatrolState());
    }
    private void Update()
    {
        if (activeState != null)
        {
            activeState.Perform();
        }
    }
    public void changeState(BaseState newState)
    {
        if (activeState != null) {
            activeState.Exit();
        }
        activeState = newState;
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.ancient = GetComponent<Ancient>();
            activeState.Enter();
        }
    }
}
