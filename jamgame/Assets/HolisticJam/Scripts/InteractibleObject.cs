using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HolisticJam
{
    public class InteractibleObject : MonoBehaviour
    {
        // needs "field:" to be actually accessible in inspector
        [field: SerializeField] public InteractionBroker Broker { get; protected set; }

        void Start()
        {
            if (Broker == null)
            {
                Broker = FindObjectOfType<InteractionBroker>();
            }

        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{other.name} entered the trigger area of {name}");
            if(other.GetComponent<MonoBehaviour>() is IInteractionRequester)
            {
                Debug.Log($"{name} in proximity to interactor");
                Broker.PerformInteraction += OnPerformInteraction;
            }
        }

        void OnTriggerExit(Collider other)
        {
            Debug.Log($"{other.name} left the trigger area of {name}");
            if(other.GetComponent<MonoBehaviour>() is IInteractionRequester)
            {
                Broker.PerformInteraction -= OnPerformInteraction;
            }
        }


        void OnPerformInteraction()
        {
            Debug.Log($"{name} performs interaction");
            // This is just some dummy action to give some feedback in the playground scene...
            Vector3 _pos = transform.position;
            _pos.y++;
            transform.position = _pos;
        }
    }
}
