using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSounds : MonoBehaviour
{

    public AudioClip BackgroundMusic_c;
    public AudioClip BackgroundAmbient_c;

    public AudioSource BackgroundAmbient;
    public AudioSource BackgroundMusic; 

	// Use this for initialization
	void Start ()
    {
        BackgroundAmbient.clip = BackgroundAmbient_c;
        BackgroundMusic.clip = BackgroundMusic_c; 
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundMusic.Play();
        BackgroundAmbient.Play();
    }
}
