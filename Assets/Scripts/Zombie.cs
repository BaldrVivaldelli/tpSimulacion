using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : NPC
{
    public static List<GameObject> humanos = new List<GameObject>();

    private GameObject target;
    private float speed = 12;
    
    private Vector3 _dirToGo;

    public GameObject zombiePrefab;

    void Start ()
    {
        Humano.zombies.Add(gameObject);
    }
	    
	void Update ()
    {
        if (!target || (target.transform.position - transform.position).magnitude < 2) {
            target = GetNextTarget();
        }        
        Seek();
    }

    private GameObject GetNextTarget()
    {

        if(target)
        {
            Instantiate(zombiePrefab, target.transform.position, Quaternion.identity);
            humanos.Remove(target);
            Destroy(target.gameObject);
        }

        int? nextValue = getRandomValue(humanos);
        if (nextValue == null) {
            gameOver();
        }
        return humanos[nextValue.Value];
    }

    void Seek()
    {
        _dirToGo = target.transform.position - transform.position;
        transform.forward = Vector3.Lerp(transform.forward, _dirToGo, base.RotationSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
