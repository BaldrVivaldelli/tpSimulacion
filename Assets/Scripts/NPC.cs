using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class NPC : MonoBehaviour {
    private float rotationSpeed = 0.5f;


    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public float RotationSpeed
    {
        get
        {
            return rotationSpeed;
        }

        set
        {
            rotationSpeed = value;
        }
    }

    protected int getRandomValue(List<GameObject> listToCount) {
        int rnd = 0 ;

		rnd = UnityEngine.Random.Range(0, listToCount.Count);				
		if (rnd == 0) {
			Debug.Log (rnd);
		}
        return rnd;
    }

    protected void gameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
