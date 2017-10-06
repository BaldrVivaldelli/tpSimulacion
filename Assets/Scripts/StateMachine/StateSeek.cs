using UnityEngine;
using System.Collections;

public class StateSeek : NPCState
{
    Vector3 _dirToGo;
    
    public StateSeek(StateMachine smac, Humano h) : base(smac, h)
    {
        
    }

    public override void Awake()
    {
        base.Awake();
    }


    public override void Execute()
    {
        base.Execute();
        _dirToGo = humano._zombie.transform.position - humano.transform.position;
        humano.transform.forward = Vector3.Lerp(humano.transform.forward, _dirToGo, humano.RotationSpeed * Time.deltaTime);
        humano.transform.position += humano.transform.forward * humano.speed * Time.deltaTime;
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
