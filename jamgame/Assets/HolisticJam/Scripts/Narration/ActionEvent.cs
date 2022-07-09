using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/EventDelegator")]
public class ActionEvent : ScriptableObject
{
    public delegate void ActionEvents(string message, params object[] parameters);
    public ActionEvents onMessageRaised;

    public void Raise(string message, params object[] parameters)
    {
        if (onMessageRaised != null)
        {
            onMessageRaised(message, parameters);
        }
    }
}
