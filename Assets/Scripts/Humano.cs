using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humano : NPC
{
    private StateMachine stateMachine;
    public static List<GameObject> zombies = new List<GameObject>();
    private List<GameObject> waypoints = new List<GameObject>();
    public GameObject _zombie;
    public int speed = 7;
    private GameObject reachZombie = null;

    void Start ()
    {
        Zombie.humanos.Add(gameObject);
        var aux = GameObject.FindGameObjectsWithTag("waypoints");
        foreach (var item in aux)
            waypoints.Add(item);

        stateMachine = new StateMachine();
        stateMachine.AddState(new StateSeek(stateMachine, this));
	}
	
	void Update ()
    {
        if (!_zombie || (_zombie.transform.position - transform.position).magnitude < 2)
            _zombie = getProximoPunto();

        stateMachine.Update();


        foreach (var zombie in zombies)
        {
            if (Vector3.Distance(zombie.transform.position, transform.position) < 10) {
                reachZombie = zombie;
            }


            if (reachZombie && stateMachine.IsActualState<StateSeek>())
            {
                _zombie = reachZombie;
                stateMachine.SetState<StateFlee>();
            }
            else if (!reachZombie && stateMachine.IsActualState<StateFlee>())
            {
                _zombie = getProximoPunto();
                stateMachine.SetState<StateFlee>();
            }
        }
    }

    private GameObject getProximoPunto()
    {
        //int rand = Random.Range(0, waypoints.Count);
        
        int random = getRandomValue(waypoints);

        return waypoints[random];
    }
    
}