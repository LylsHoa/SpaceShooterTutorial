using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;


	// Use this for initialization
	void Start ()
    {

        audioSource = GetComponent<AudioSource>();

        //repetitively invoke a function; this is where we call FIRE
        InvokeRepeating ("Fire", delay, fireRate);


		
	}

    void Fire ()
    {
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play ();




    }
	

}
