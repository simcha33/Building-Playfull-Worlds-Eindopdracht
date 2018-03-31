using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI; 
using UnityEngine;

public class Monster1 : MonoBehaviour {

    public GameObject Player;

    private NavMeshAgent nav;

    private string state = "idle";
    private bool alive = true; 


	void Start ()
    {
        nav = GetComponent <NavMeshAgent>(); 
	}
	

	void Update ()
    {
        if (alive)
        {
            //nav.SetDestination(Player.transform.position); 

            //Iddle
            if(state == "idle")
            {
                //Pick a random place to move to 
                Vector3 rPos = Random.insideUnitSphere*20f;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + rPos, out navHit, 20f, NavMesh.AllAreas);
                nav.SetDestination(navHit.position);
                state = "walk"; 
            }

            if (state == "walk")
            {
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "idle";
                }
            }

            }
        }
	}

