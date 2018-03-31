using UnityEngine;
using System.Collections;

public class weapon_s : MonoBehaviour {

	public float damage = 10f; 
	public float range = 100f; 
	public float firerate = 10f; 

	public Camera fpsCam; 	
	public ParticleSystem Muzzle; 
	public GameObject BloodEffect;

    public int AmmoCount = 20;
    private int CurrentAmmo;
    public float ReloadTime = 1f; 


	private float FireTime = 0f;
    private bool Reloading = false;

    public AudioClip Reload;
    public AudioClip Shooting;

    public AudioSource ReloadSound;
    public AudioSource ShootSound;


    private void Start()
    {
        CurrentAmmo = AmmoCount;
        ReloadSound.clip = Reload;
        ShootSound.clip = Shooting; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Reloading)
            return;

        if (CurrentAmmo < AmmoCount)
        {

            if (CurrentAmmo == 0 || Input.GetKey(KeyCode.R))
            {
                StartCoroutine(ReloadGun());
                return;
            }
        }
	
		if (Input.GetButton("Fire1") && Time.time >= FireTime)
		{
			FireTime = Time.time + 1f / firerate; 
			Shoot();

		}
	}

	void Shoot () 
	{
		Muzzle.Play ();
        CurrentAmmo--;
        ShootSound.Play(); 

		RaycastHit hit; 
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Debug.Log (hit.transform.name); 

			Target target = hit.transform.GetComponent<Target> ();
			if (target != null)
			{
                target.TakeDamage(damage);
                GameObject ImpactEffect = Instantiate(BloodEffect, hit.point, Quaternion.LookRotation (hit.normal));
                Destroy(ImpactEffect, .3f);

            }

  
	
			
        }
	}

    IEnumerator ReloadGun()
    {
        Reloading = true;
        yield return new WaitForSeconds(ReloadTime); 
        CurrentAmmo = AmmoCount;
        print("Reloading");
        ReloadSound.Play(); 
        Reloading = false; 

    }
}