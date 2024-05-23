using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/05/2024]
 * [Responsible for displaying the user interface]
 */

public class HUDController : Observer
{
    //local bool to get the turbo status, and current health in the bike controller class
    private bool isTurboOn;
    private float currentHealth;

    //reference to the bike controller
    private BikeController bikeController;

    /// <summary>
    /// TESTING PURPOSES ONLY ( DO NOT USE IN PRODUCTION CODE ) EXTREMELY INEFFICIENT
    /// </summary>
    private void OnGUI()
    {
        //display the current health in a box UI element
        GUILayout.BeginArea(new Rect(50, 50, 100, 200));
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("Health: " + currentHealth);
        GUILayout.EndHorizontal();

        //if the bikes turbo is on
        if(isTurboOn)
        {
            //display that the turbo is activated via UI text
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Turbo Activated");
            GUILayout.EndHorizontal();
        }

        //if the bikes health is less than or equal to 50
        if (currentHealth <= 50f)
        {
            //display a low health warning via UI text
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("WARNING LOW HEALTH!");
            GUILayout.EndHorizontal();
        }

        GUILayout.EndArea();
    }

    /// <summary>
    /// Recieve a reference to the subject that notified it. 
    /// It can then access the subjects properties and choose which one to display in the interface
    /// </summary>
    /// <param name="subject"></param>
    public override void Notify(Subject subject)
    {
        //throw new System.NotImplementedException();

        //if bike controller is not initialized
        if(!bikeController)
        {
            //get the bike controller component of the passed in subject and initialize bikeController
            bikeController = subject.GetComponent<BikeController>();
        }

        //if bike controller is ininitialized
        if (bikeController)
        {
            //set the isTurboOn bool equal to the bike controllers IsTurboOn bool property
            isTurboOn = bikeController.IsTurboOn;

            //set the currentHealth equal to the bike controllers CurrentHealth float property
            currentHealth = bikeController.CurrentHealth;
        }
    }
}
