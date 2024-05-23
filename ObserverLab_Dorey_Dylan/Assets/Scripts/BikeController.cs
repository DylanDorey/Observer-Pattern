using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/05/2024]
 * [The user controlled bike controller]
 */

public class BikeController : Subject
{
    //determines if the engine is on or not
    private bool isEngineOn;

    //references to the HUDController and the cameraController
    private HUDController hudController;
    private CameraController cameraController;

    //bike controllers health
    [SerializeField]
    private float health = 100;

    //property to determine if the turbo mode is on
    public bool IsTurboOn
    {
        get;
        private set;
    }

    //property for the health of the bike
    public float CurrentHealth
    {
        get { return health; }
    }

    private void Awake()
    {
        //add and initialize a hudController component
        hudController = gameObject.AddComponent<HUDController>();

        //initialize the cameraController by finding a cameraController and casting it as a cameraController
        cameraController = (CameraController) FindObjectOfType(typeof(CameraController));
    }

    private void Start()
    {
        //start the engine of the bike
        StartEngine();
    }

    // This next part is critical because we are attaching our observer when BikeController is enabled
    // but also detaching them when its disabled. this avoids us having to hold onto references
    // we dont need anymore.

    private void OnEnable()
    {
        //if hudController is initialized
        if (hudController)
        {
            //attach it as an observer
            Attach(hudController);
        }

        //if cameraController is initialized
        if (cameraController)
        {
            //attach it as an observer
            Attach(cameraController);
        }
    }

    private void OnDisable()
    {
        //if hudController is initialized
        if (hudController)
        {
            //detach the observer
            Detach(hudController);
        }

        //if cameraController is initialized
        if (cameraController)
        {
            //detach the observer
            Detach(cameraController);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// Starts the engine of engine of the bike
    /// </summary>
    private void StartEngine()
    {
        //set is engine on to true
        isEngineOn = true;

        //notify any observers that depend on this variable of the bike
        NotifyObservers();
    }

    /// <summary>
    /// BikeController never calls HUDController or CameraController directly. It only notifies them that something has changed - it never tells them what to do
    /// This is important because the observers can independently choose how to be notified. That means they're decoupled
    /// </summary>
    public void ToggleTurbo()
    {
        //if the bike's engine is on
        if (isEngineOn)
        {
            //toggle the turbo on or off
            IsTurboOn = !IsTurboOn;
        }

        //notify any observers that depend on this variable of the bike
        NotifyObservers();
    }

    /// <summary>
    /// Removes health from the bike controller depending on the incoming amount
    /// </summary>
    /// <param name="amount"> the incoming damage </param>
    public void TakeDamage(float amount)
    {
        //remove the amount from health and turn the turbo off
        health -= amount;
        IsTurboOn = false;

        //notify any observers that depend on this variable of the bike
        NotifyObservers();

        //if our health is less than 0
        if(health < 0)
        {
            //destroy the game object
            Destroy(gameObject);
        }
    }
}

