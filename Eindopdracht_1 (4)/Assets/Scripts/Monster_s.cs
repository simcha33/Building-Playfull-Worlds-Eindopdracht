using UnityEngine;
using System.Collections;

public class Monster_s : MonoBehaviour
{

    public float TargetDistance;
    public float LookDistance;
    public float AttackDistance;
    public float MoveSpeed;
    public float damping;
    public Transform target;

    Rigidbody theRigidBody;
    RenderBuffer myREnder;
    Renderer myRender;


    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        if (TargetDistance > LookDistance)
        {
            myRender.material.color = Color.green;
        }
       
        TargetDistance = Vector3.Distance(target.position, transform.position);
        if (TargetDistance < LookDistance)
        {
            LookAtPlayer();
            transform.LookAt(target);
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
            myRender.material.color = Color.yellow; 

        }
        if (TargetDistance < AttackDistance)
        {
            AttackPlayer(); 
        }
    }

    void AttackPlayer()
    {
        theRigidBody.AddForce(transform.forward * MoveSpeed);
        myRender.material.color = Color.red; 
    }

    void LookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime + damping);
    }
}

