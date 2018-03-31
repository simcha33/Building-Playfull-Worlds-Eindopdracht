using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{

    public GameObject TargetDoor;

    public bool doorIsOpening = false;
    public bool doorIsClosing = false;
    public bool canOpenAndClose = true;

    public float maxDoorHeight;
    public float doorSpeed = 0.05f;
    public float triggerDist = 2f;
    private float startPosY;

    public AudioClip Activate;
    public AudioSource ActivateSound; 
   

    private void Start()
    {
        startPosY = TargetDoor.transform.position.y;
        ActivateSound.clip = Activate; 
        
    }

    private void FixedUpdate()
    {
        if (doorIsOpening)
        {
            ActivateSound.Play();
            TargetDoor.transform.Translate(new Vector3(0, doorSpeed, 0));
            if (TargetDoor.transform.position.y >= maxDoorHeight)
            {
                TargetDoor.transform.position = new Vector3(TargetDoor.transform.position.x, maxDoorHeight, TargetDoor.transform.position.z);
                doorIsOpening = false;
            }
        }
        if (doorIsClosing)
        {
            ActivateSound.Play();
            TargetDoor.transform.Translate(new Vector3(0, -doorSpeed, 0));
            if (TargetDoor.transform.position.y <= startPosY)
            {
                TargetDoor.transform.position = new Vector3(TargetDoor.transform.position.x, startPosY, TargetDoor.transform.position.z);
                doorIsClosing = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && !doorIsOpening)
        {
  
            RaycastHit hInfo = new RaycastHit();
            if (Physics.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), out hInfo, 10))
            {
                if (hInfo.collider.gameObject == gameObject)
                {
                    if (TargetDoor.transform.position.y == maxDoorHeight && canOpenAndClose)
                    {
                        doorIsOpening = false;
                        doorIsClosing = true;
                    }
                    else if (TargetDoor.transform.position.y == startPosY)
                    {
                        doorIsOpening = true;
                        doorIsClosing = false;
                    }

                }
            }
        }
    }
}
