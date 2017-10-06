using UnityEngine;
using System.Collections;

public abstract class NPCState : State {

    protected Humano humano;

    public NPCState(StateMachine smac, Humano h) : base(smac)
    {
        humano = h;
    }
}
