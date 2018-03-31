using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch2 : MonoBehaviour
{

    public GameObject Door2;
    public bool Door2IsOpening;
    private GameObject Switch2;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Door2IsOpening == true)
        {
            Door2.transform.Translate(Vector3.up * Time.deltaTime * 5);
            //if the bool is true open the Door2
        }
        if (Door2.transform.position.y > 7f)
        {
            Door2IsOpening = false;

            //if the y of the Door2 is more than 7 the Door2 stops 
        }

        int layer = LayerMask.NameToLayer("Switch1");
        RaycastHit hitInfo;
        if (Input.GetKey(KeyCode.E))
        {
            if (Switch2 == null)
            {
                if (Physics.Raycast(transform.position + transform.forward, transform.forward, out hitInfo, 2.0f, 1 << layer))
                {
                    Switch2 = hitInfo.collider.gameObject;
                    Door2IsOpening = true;
                    print("OpeningDoor2");

                }

            }

        }
    }
}


