using UnityEngine;
using System.Collections;

public class Monster_V3 : MonoBehaviour
{

    public float TargetDistance;
    public float LookDistance;
    public float AttackDistance;
    public float MoveSpeed;
    public float damping;

    private Animator anim;

    public Transform target;

    Rigidbody theRigidBody;




    void Start()
    {
        theRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        // idle 
        if (TargetDistance > LookDistance)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walking", false);
            anim.SetBool("Attacking", false);
        }

        //moving
        TargetDistance = Vector3.Distance(target.position, transform.position);
        if (TargetDistance < LookDistance)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", true);
            anim.SetBool("Attacking", false);
            LookAtPlayer();
            transform.LookAt(target);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);

        }
        //attacking
        if (TargetDistance < AttackDistance)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", false);
            anim.SetBool("Attacking", true);
            AttackPlayer();
            print("attack");
        }
    }

    void AttackPlayer()
    {
        theRigidBody.AddForce(transform.forward * MoveSpeed);
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + damping);
    }


}