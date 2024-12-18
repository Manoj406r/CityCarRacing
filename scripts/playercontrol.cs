using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    [Header("wheelcolliders")]
    public WheelCollider frontleftwheelcollider;
    public WheelCollider frontrightwheelcollider;
    public WheelCollider backleftwheelcollider;
    public WheelCollider backrightwheelcollider;

    [Header("wheeltransforms")]
    public Transform frontleftwheeltransform;
    public Transform frontrightwheeltransform;
    public Transform backleftwheeltransform;
    public Transform backrightwheeltransform;

    [Header("car engine")]
    public float accelarationforce = 300f;
    public float breakforce = 3000f;
    private float presentaccelartion = 0f;
    private float presentbreakforce = 0f;

    [Header("carsteering")]
    public float wheeltorque = 35f;
    private float presentturnangle = 0f;
    public AudioSource highspeed;
    public AudioClip highspeed1;
    public AudioClip lowspeed1;
    public AudioClip idlesound;

   
    
    private void Start()
    {
      
        highspeed = GetComponent<AudioSource>();
       
    }
    private void Update()
    {
        carmove();
        carsteering();

    }

    private void carmove()
    {
        //car movement
        frontleftwheelcollider.motorTorque = presentaccelartion;
        frontrightwheelcollider.motorTorque = presentaccelartion;
        backleftwheelcollider.motorTorque = presentaccelartion;
        backrightwheelcollider.motorTorque = presentaccelartion;

        presentaccelartion = accelarationforce * SimpleInput.GetAxis("Vertical");

        if (presentaccelartion > 0)
        {
            highspeed.PlayOneShot(highspeed1, 0.2f);
        }
        else if (presentaccelartion < 0)
        {
            highspeed.PlayOneShot(lowspeed1, 0.2f);
        }
        else if (presentaccelartion == 0)
        {
            highspeed.PlayOneShot(idlesound, 0.1f);
        }


    }

    private void carsteering()
    {
        //car turn
        frontleftwheelcollider.steerAngle = presentturnangle;
        frontrightwheelcollider.steerAngle = presentturnangle;

        presentturnangle = wheeltorque * SimpleInput.GetAxis("Horizontal");

        steeringwheels(frontleftwheelcollider, frontleftwheeltransform);
        steeringwheels(frontrightwheelcollider, frontrightwheeltransform);
        steeringwheels(backleftwheelcollider, backleftwheeltransform);
        steeringwheels(backrightwheelcollider, backrightwheeltransform);


    }
    void steeringwheels(WheelCollider wc, Transform wt)
    {
        //tyre turn
        Vector3 position;
        Quaternion rotation;
        wc.GetWorldPose(out position, out rotation);
        wt.position = position;
        wt.rotation = rotation;

    }

    public void applybrake()
    {

      
        
            StartCoroutine(carbrakesystem());
        StartCoroutine(carbrakesystem());
        StartCoroutine(carbrakesystem());
        StartCoroutine(carbrakesystem());





    }
    IEnumerator carbrakesystem()
    {

        presentbreakforce = breakforce;

        frontleftwheelcollider.brakeTorque = presentbreakforce;
        frontrightwheelcollider.brakeTorque = presentbreakforce;
        backleftwheelcollider.brakeTorque = presentbreakforce;
        backrightwheelcollider.brakeTorque = presentbreakforce;

        yield return new WaitForSeconds(2f);
        presentbreakforce = 0f;

        frontleftwheelcollider.brakeTorque = presentbreakforce;
        frontrightwheelcollider.brakeTorque = presentbreakforce;
        backleftwheelcollider.brakeTorque = presentbreakforce;
        backrightwheelcollider.brakeTorque = presentbreakforce;

    }

}