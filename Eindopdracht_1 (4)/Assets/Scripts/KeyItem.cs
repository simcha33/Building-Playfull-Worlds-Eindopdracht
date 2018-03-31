using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {

	void onTriggerEnter(Collider collider)
        {
            if (collider.gameObject.name == "Player")
                {
                    GameVariables.keyCount += 2;
            Destroy(gameObject); 
                }

        }
}
