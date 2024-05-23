using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/05/2024]
 * [A subject that attaches and detaches observes to the main subject entity/game object]
 */

public abstract class Subject : MonoBehaviour
{
    //A list of observers that notify the subject of any events that take place
    private readonly ArrayList _observers = new ArrayList();

    /// <summary>
    /// Adds an observer to the observers list and attaches the observer to the subject
    /// </summary>
    /// <param name="observer"> the class that notifies the subject game object of unique changes/events </param>
    protected void Attach(Observer observer)
    {
        //add the observer to the list of observers
        _observers.Add(observer);
    }

    /// <summary>
    /// Removes an observer from the observers list and detaches the observer from the subject
    /// </summary>
    /// <param name="observer"> the class that notifies the subject game object of unique changes/events </param>
    protected void Detach(Observer observer)
    {
        //remove the observer from the list of observers
        _observers.Remove(observer);
    }

    /// <summary>
    /// Notifies any observers that are attached of an event that has happened
    /// </summary>
    protected void NotifyObservers()
    {
        //for each of the elements in the list of observers
        foreach (Observer observer in _observers)
        {
            //notify them of the event and pass this class as the reference
            observer.Notify(this);
        }
    }
}
