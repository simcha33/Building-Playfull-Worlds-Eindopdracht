using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_V2 : MonoBehaviour
{

    public GameObject Player;
    public float Distance;
    public float Range;
    public GameObject Monster;
    public float Speed;
    public float AttackTrigger;
    public RaycastHit Shot;

    // Use this for initialization
    void Start()
    {
        transform.LookAt(Player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            Distance = Shot.distance;
            if (Distance < Range)
            {
                Speed = 0.02f;
                if (AttackTrigger == 0)
                {
                    print("walking");
                    transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed);
                   
                }
            }

            else
            {
                print("Idle)");
                Speed = 0; 
            }
        }
        if (AttackTrigger == 1)
        {
            print("Attack"); 
        }
    }
}
