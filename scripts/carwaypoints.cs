using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carwaypoints : MonoBehaviour
{
    [Header("opponentcar")]
    public opponentcar opponentcar;
    public waypoint currentwaypoint;

    private void Awake()
    {
        opponentcar = GetComponent<opponentcar>();
    }

    private void Start()
    {
        opponentcar.locatedestination(currentwaypoint.GetPosition());

    }
    private void Update()
    {
        if(opponentcar.destinationreached)
        {
            currentwaypoint = currentwaypoint.nextwaypoint;
            opponentcar.locatedestination(currentwaypoint.GetPosition());
        }
    }
}
