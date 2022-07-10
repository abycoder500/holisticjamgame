using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEventMessageReceiver : MonoBehaviour
{
    [SerializeField] private ActionEvent _delegator;
    
    private void OnEnable()
    {
        _delegator.onMessageRaised += SpreadMessage;
    }

    private void OnDisable()
    {
        _delegator.onMessageRaised += SpreadMessage;
    }

    private void SpreadMessage(string action, params object[] parameters)
    {
        gameObject.SendMessage(action, parameters);
    }
}
