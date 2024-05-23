using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/05/2024]
 * [Responsible for screen shake when bike controller turbo is activated]
 */

public class CameraController : Observer
{
    //local bool to get the turbo status in the bike controller class
    private bool isTurboOn;

    //the starting default position of the bike controller
    private Vector3 initialPostion;

    //how much/far the bike will shake from the initial position
    private float shakeMagnitude = 0.1f;

    //reference to the bike controller
    private BikeController bikeController;

    private void OnEnable()
    {
        //initialize the initial position to the starting position of the bike
        initialPostion = gameObject.transform.localPosition;
    }

    /// <summary>
    /// Simple BAD version of screen shake
    /// ONLY USED FOR TESTING PURPOSES
    /// </summary>
    private void Update()
    {
        //if the turbo is on
        if(isTurboOn)
        {
            //set the initial position plus a random position inside a unit sphere of the bike controller, time the shake magnitude (distance from initial position)
            gameObject.transform.localPosition = initialPostion + (Random.insideUnitSphere * shakeMagnitude);
        }
        else
        {
            //otherwise set the local position to the initial position
            gameObject.transform.localPosition = initialPostion;
        }
    }

    /// <summary>
    /// All we do here in notify is get the reference to the BikeController
    /// and then set our local reference to the isTurboOn
    /// </summary>
    /// <param name="subject"></param>
    public override void Notify(Subject subject)
    {
        //throw new System.NotImplementedException();

        //if bike controller is not initialized
        if (!bikeController)
        {
            //get the bike controller component of the passed in subject and initialize bikeController
            bikeController = subject.GetComponent<BikeController>();
        }

        //if bike controller is ininitialized
        if (bikeController)
        {
            //set the isTurboOn bool equal to the bike controllers IsTurboOn bool property
            isTurboOn = bikeController.IsTurboOn;
        }
    }
}
