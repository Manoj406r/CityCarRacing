using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opponentcar : MonoBehaviour
{
    [Header("car engine")]
    public float movingspeed;
    public float turningspeed = 50f;
    public float breakspeed = 12f;

    [Header("destination var")]
    public Vector3 destination;
    public bool destinationreached;
    public AudioSource crashsound;
    public AudioClip crashsound1;


    private void Update()
    {
        drive();
    }

    public void drive()
    {
        if(transform.position != destination)
        {
            Vector3 destinationdirection = destination - transform.position;
            destinationdirection.y = 0;
            float destinationdistance= destinationdirection.magnitude;

           if(destinationdistance >=breakspeed)
            {
                destinationreached = false;
                Quaternion targetrotation = Quaternion.LookRotation(destinationdirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetrotation, turningspeed * Time.deltaTime);


                //move vehicle
                transform.Translate(Vector3.forward * movingspeed * Time.deltaTime);

            }
           else
            {
                destinationreached = true;
            }
        }

    }
    public void locatedestination(Vector3 destination)
    {
        this.destination = destination;
        destinationreached = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            crashsound.PlayOneShot(crashsound1, 0.02f);
        }
    }

}
