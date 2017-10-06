using UnityEngine;
using System.Collections;

public abstract class State
{
    private StateMachine stateMachine;

    public State(StateMachine state)
    {
        stateMachine = state;
    }

    public virtual void Awake() {

     }

    public virtual void Sleep() {

     }

    public virtual void Execute() {

     }

}
