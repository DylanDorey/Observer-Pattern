using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/05/2024]
 * [The client component that controls user functionality]
 */

public class ClientObserver : MonoBehaviour
{
    //reference to the bike controller
    private BikeController bikeController;

    private void Start()
    {
        //initialize bikeController with a found component of type BikeController, cast this component as a BikeController as a safety net
        bikeController = (BikeController)FindObjectOfType(typeof(BikeController));
    }

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //create a damage bike button
        if(GUILayout.Button("Damage Bike"))
        {
            //if bike controller is initialized
            if(bikeController)
            {
                //if pressed, deal 15 damage to the bike
                bikeController.TakeDamage(15f);
            }
        }

        // create a toggle turbo button
        if (GUILayout.Button("Toggle Turbo"))
        {
            //if bike controller is initialized
            if (bikeController)
            {
                //if pressed, toggle the bike controllers turbo mode on/off
                bikeController.ToggleTurbo();
            }
        }
    }
}
