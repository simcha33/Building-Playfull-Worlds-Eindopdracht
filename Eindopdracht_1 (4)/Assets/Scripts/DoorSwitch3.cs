using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch3 : MonoBehaviour
{

    public GameObject Door3;
    public bool Door3IsOpening;
    private GameObject Switch;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Door3IsOpening == true)
        {
            Door3.transform.Translate(Vector3.up * Time.deltaTime * 5);
            //if the bool is true open the Door3
        }
        if (Door3.transform.position.y > 7f)
        {
            Door3IsOpening = false;

            //if the y of the Door3 is more than 7 the Door3 stops 
        }

        int layer = LayerMask.NameToLayer("Switch1");
        RaycastHit hitInfo;
        if (Input.GetKey(KeyCode.E))
        {
            if (Switch == null)
            {
                if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hitInfo, 2.0f, 1 << layer))
                {
                    Switch = hitInfo.collider.gameObject;
                    Door3IsOpening = true;
                    print("OpeningDoor3");

                }

            }

        }
    }
}

