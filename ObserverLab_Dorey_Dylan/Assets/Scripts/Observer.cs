using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Dorey, Dylan]
 * Last Updated: [03/05/2024]
 * [An observer that notifies the observer of a specific event that has happened]
 */

public abstract class Observer : MonoBehaviour
{
    /// <summary>
    /// Notifies the subject that is passed in as a parameter of the change
    /// </summary>
    /// <param name="subject"> the host/subject game object that is being changed by the observer </param>
    public abstract void Notify(Subject subject);
}
