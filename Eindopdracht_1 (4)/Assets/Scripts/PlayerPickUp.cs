using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour {

    private GameObject PickUpObj; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        int layer = LayerMask.NameToLayer("PickUps");
        RaycastHit hitInfo; 
        if (Input.GetKey(KeyCode.E))
        {
           
            if (PickUpObj == null)
            {
                if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hitInfo, 1.0f, 1 << layer))
                {
                    PickUpObj = hitInfo.collider.gameObject;
                    PickUpObj.transform.parent = transform; //parent de player camera en het object samen 
                    ((Rigidbody)PickUpObj.GetComponent(typeof(Rigidbody))).isKinematic = true;
                    print("PickUp");
                }      
            }
            else
            {
                ((Rigidbody)PickUpObj.GetComponent(typeof(Rigidbody))).isKinematic = false;
                PickUpObj.transform.parent = null;

                PickUpObj = null;
            }
        }
	}
}
