using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{

    public Vector2 startWait;
    public Vector2 manueverTime;
    public Vector2 manueverWait;
    public Boundary boundary;

    public float tilt;
    public float dodge;
    public float smoothing;

    private float targetManeuver;

    private float currentSpeed;

    private Rigidbody rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = rb.velocity.z;

        StartCoroutine(Evade());

    }

    IEnumerator Evade()
    {

        //Evade by setting a target value along the x-axis then moving towards it over time
        //to set x and y values in inspector 
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));


        while (true)
        {
            //picking a numebr between 1-(dodge- aka number we set)
            //mathf tells the ship to dodge inwards depending on what side it's on (neg or pos of the middle (0))
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(manueverTime.x, manueverTime.y));

            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(manueverWait.x, manueverWait.y));

        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //moving something 1 place to another w/o lerp 
        //(what im moving, what im moving it towards, maxspeed i can move it)
        float newManuever = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);

        //To always go down the z-axis at the current speed
        rb.velocity = new Vector3(newManuever, 0.0f, currentSpeed);

        //just in case enemy leaves screen SOMEHOW, clamp it inside the screen

        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        //to tilt enemy like playership
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * tilt);




    }
}
